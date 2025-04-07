import { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';
import { 
  fetchProducts, 
  fetchProductsByCategory,
  fetchProductsBySubCategory 
} from '../../services/api';
import { PageLoader } from '../../components/Loading';
import Card from '../../components/Card';
import { getDefaultProductImage, DEFAULT_IMAGES } from '../../utils/constants';

const ProductList = () => {
  const { categoryId, subcategoryId } = useParams();
  const [products, setProducts] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  useEffect(() => {
    const loadProducts = async () => {
      try {
        setLoading(true);
        let data;
        
        if (subcategoryId) {
          data = await fetchProductsBySubCategory(subcategoryId);
        } else if (categoryId) {
          data = await fetchProductsByCategory(categoryId);
        } else {
          data = await fetchProducts();
        }

        if (!data) {
          throw new Error('No products found');
        }

        setProducts(Array.isArray(data) ? data : []);
      } catch (error) {
        console.error('Error loading products:', error);
        setError('Failed to load products');
      } finally {
        setLoading(false);
      }
    };

    loadProducts();
  }, [categoryId, subcategoryId]);

  if (loading) return <PageLoader />;

  if (error) {
    return (
      <div className="text-center text-red-600">
        {error}
      </div>
    );
  }

  if (products.length === 0) {
    return (
      <div className="text-center text-gray-500 py-12">
        <h3 className="text-lg font-medium">No products found</h3>
        <p className="mt-2">Try selecting a different category or check back later.</p>
      </div>
    );
  }

  return (
    <div className="space-y-8">
      <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-8">
        {products.map(product => (
          <Card key={product.id} padding="small">
            <div className="aspect-w-3 aspect-h-2">
              <img
                // src={product.imageUrl || 'https://via.placeholder.com/300x200'}
                src={getDefaultProductImage(product)}
                alt={product.name}
                onError={(e) => {
                  e.target.src = DEFAULT_IMAGES.product;
                }}
                className="object-cover rounded-t-lg w-full h-48"
              />
            </div>
            <div className="p-4">
              <h3 className="text-lg font-medium text-gray-900">{product.name}</h3>
              <p className="mt-1 text-sm text-gray-500 line-clamp-2">
                {product.description}
              </p>
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
  );
};

export default ProductList; 