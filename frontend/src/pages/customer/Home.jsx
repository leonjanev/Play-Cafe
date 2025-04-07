import { useState, useEffect } from 'react';
import { fetchProducts, fetchSubcategories, fetchCategories } from '../../services/api';
import { PageLoader } from '../../components/Loading';
import Card from '../../components/Card';
import Video from '../../components/Video';
import { getDefaultProductImage, DEFAULT_IMAGES } from '../../utils/constants';

const Home = () => {
  const [products, setProducts] = useState([]);
  const [categories, setCategories] = useState([]);
  const [subcategories, setSubcategories] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);
  const [selectedCategory, setSelectedCategory] = useState(null);

  useEffect(() => {
    const loadData = async () => {
      try {
        setLoading(true);
        const [productsData, subcategoriesData, categoriesData] = await Promise.all([
          fetchProducts(),
          fetchSubcategories(),
          fetchCategories()
        ]);
        setProducts(productsData);
        setSubcategories(subcategoriesData);
        setCategories(categoriesData);
      } catch (error) {
        console.error('Error fetching data:', error);
        setError('Failed to load data');
      } finally {
        setLoading(false);
      }
    };
    loadData();
  }, []);

  if (loading) return <PageLoader />;

  const filteredProducts = selectedCategory
    ? products.filter(product => {
        const subcategory = subcategories.find(sub => sub.id === product.subCategoryId);
        return subcategory && subcategory.categoryId === selectedCategory;
      })
    : products;

  return (
    <div className="bg-gray-50">
      {/* Video Hero Section */}
      <Video />

      {/* Category Filter */}
      <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8 py-8">
        <div className="flex space-x-4 overflow-x-auto pb-4">
          <button
            onClick={() => setSelectedCategory(null)}
            className={`px-4 py-2 rounded-full ${
              !selectedCategory 
                ? 'bg-primary-600 text-white' 
                : 'bg-white text-gray-700 hover:bg-gray-50'
            } font-medium text-sm`}
          >
            All
          </button>
          {categories.map(category => (
            <button
              key={category.id}
              onClick={() => setSelectedCategory(category.id)}
              className={`px-4 py-2 rounded-full ${
                selectedCategory === category.id
                  ? 'bg-primary-600 text-white'
                  : 'bg-white text-gray-700 hover:bg-gray-50'
              } font-medium text-sm`}
            >
              {category.name}
            </button>
          ))}
        </div>
      </div>

      {/* Products Grid */}
      <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8 pb-24">
        <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-8">
          {filteredProducts.map(product => (
            <Card key={product.id} padding="small">
              <div className="aspect-w-3 aspect-h-2">
                <img
                  src={getDefaultProductImage(product)}
                  alt={product.name}
                  className="object-cover rounded-t-lg w-full h-48"
                  onError={(e) => {
                    e.target.src = DEFAULT_IMAGES.product;
                  }}
                />
              </div>
              <div className="p-4">
                <h3 className="text-lg font-medium text-gray-900">{product.name}</h3>
                <p className="mt-1 text-sm text-gray-500 line-clamp-2">{product.description}</p>
                <div className="mt-4 flex justify-between items-center">
                  <span className="text-lg font-medium text-gray-900">
                    ${product.price.toFixed(2)}
                  </span>
                  {product.isAvailable ? (
                    <span className="inline-flex items-center px-2.5 py-0.5 rounded-full text-xs font-medium bg-green-100 text-green-800">
                      Available
                    </span>
                  ) : (
                    <span className="inline-flex items-center px-2.5 py-0.5 rounded-full text-xs font-medium bg-red-100 text-red-800">
                      Unavailable
                    </span>
                  )}
                </div>
              </div>
            </Card>
          ))}
        </div>
      </div>
    </div>
  );
};

export default Home; 