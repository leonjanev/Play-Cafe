import { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import Table from '../../../components/Table';
import { PageLoader } from '../../../components/Loading';
import PageHeader from '../../../components/PageHeader';
import Card from '../../../components/Card';
import { fetchProducts, deleteProduct, fetchSubcategories, fetchCategories } from '../../../services/api';

const Products = () => {
  const [products, setProducts] = useState([]);
  const [subcategories, setSubcategories] = useState([]);
  const [categories, setCategories] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);
  const navigate = useNavigate();

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

  const getSubcategoryName = (subCategoryId) => {
    const subcategory = subcategories.find(s => s.id === subCategoryId);
    if (!subcategory) return 'N/A';
    
    const category = categories.find(c => c.id === subcategory.categoryId);
    return (
      <div>
        <div className="text-gray-900">{subcategory.name}</div>
        <div className="text-gray-500 text-sm">
          {category ? category.name : ''}
        </div>
      </div>
    );
  };

  const columns = [
    { 
      key: 'name', 
      label: 'Product',
      render: (item) => (
        <div className="flex items-center">
          {item.imageUrl && (
            <img 
              src={item.imageUrl} 
              alt={item.name}
              className="h-10 w-10 rounded-full mr-3 object-cover"
            />
          )}
          <div>
            <div className="font-medium text-gray-900">{item.name}</div>
            <div className="text-gray-500 text-sm truncate max-w-xs">
              {item.description}
            </div>
          </div>
        </div>
      )
    },
    { 
      key: 'price', 
      label: 'Price',
      render: (item) => (
        <span className="text-gray-900">
          ${parseFloat(item.price).toFixed(2)}
        </span>
      )
    },
    { 
      key: 'subCategoryId', 
      label: 'Category',
      render: (item) => getSubcategoryName(item.subCategoryId)
    },
    { 
      key: 'isAvailable', 
      label: 'Status',
      render: (item) => (
        <span className={`inline-flex items-center px-2.5 py-0.5 rounded-full text-xs font-medium ${
          item.isAvailable 
            ? 'bg-green-100 text-green-800'
            : 'bg-red-100 text-red-800'
        }`}>
          {item.isAvailable ? 'Available' : 'Unavailable'}
        </span>
      )
    },
  ];

  const handleEdit = (product) => {
    navigate(`/products/edit/${product.id}`);
  };

  const handleDelete = async (product) => {
    if (window.confirm('Are you sure you want to delete this product?')) {
      try {
        await deleteProduct(product.id);
        setProducts(products.filter((p) => p.id !== product.id));
      } catch (error) {
        console.error('Error deleting product:', error);
      }
    }
  };

  if (loading) return <PageLoader />;

  const AddButton = (
    <button
      onClick={() => navigate('/products/create')}
      className="inline-flex items-center px-4 py-2 border border-transparent shadow-sm text-sm font-medium rounded-md text-white bg-primary-600 hover:bg-primary-700 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-primary-500"
    >
      <svg className="-ml-1 mr-2 h-5 w-5" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke="currentColor">
        <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M12 6v6m0 0v6m0-6h6m-6 0H6" />
      </svg>
      Add Product
    </button>
  );

  return (
    <div className="space-y-6">
      <PageHeader
        title="Products"
        description="Manage your product catalog"
        action={AddButton}
      />

      {error && (
        <div className="rounded-md bg-red-50 p-4">
          <div className="flex">
            <div className="flex-shrink-0">
              <svg className="h-5 w-5 text-red-400" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 20 20" fill="currentColor">
                <path fillRule="evenodd" d="M10 18a8 8 0 100-16 8 8 0 000 16zM8.707 7.293a1 1 0 00-1.414 1.414L8.586 10l-1.293 1.293a1 1 0 101.414 1.414L10 11.414l1.293 1.293a1 1 0 001.414-1.414L11.414 10l1.293-1.293a1 1 0 00-1.414-1.414L10 8.586 8.707 7.293z" clipRule="evenodd" />
              </svg>
            </div>
            <div className="ml-3">
              <h3 className="text-sm font-medium text-red-800">{error}</h3>
            </div>
          </div>
        </div>
      )}

      <Card>
        <Table
          columns={columns}
          data={Array.isArray(products) ? products : []}
          onEdit={handleEdit}
          onDelete={handleDelete}
        />
      </Card>
    </div>
  );
};

export default Products;