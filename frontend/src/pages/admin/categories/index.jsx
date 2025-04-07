import { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import Table from '../../../components/Table';
import { PageLoader } from '../../../components/Loading';
import PageHeader from '../../../components/PageHeader';
import Card from '../../../components/Card';
import ConfirmDialog from '../../../components/ConfirmDialog';
import { fetchCategories, deleteCategory } from '../../../services/api';

const Categories = () => {
  const navigate = useNavigate();
  const [categories, setCategories] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);
  const [deleteDialogOpen, setDeleteDialogOpen] = useState(false);
  const [categoryToDelete, setCategoryToDelete] = useState(null);

  useEffect(() => {
    const loadData = async () => {
      try {
        const data = await fetchCategories();
        setCategories(data);
      } catch (error) {
        setError('Failed to load categories');
      } finally {
        setLoading(false);
      }
    };
    loadData();
  }, []);

  const handleEdit = (category) => {
    navigate(`/admin/categories/edit/${category.id}`);
  };

  const handleDeleteClick = (category) => {
    setCategoryToDelete(category);
    setDeleteDialogOpen(true);
  };

  const handleDeleteConfirm = async () => {
    try {
      await deleteCategory(categoryToDelete.id);
      setCategories(categories.filter(c => c.id !== categoryToDelete.id));
      setDeleteDialogOpen(false);
      setCategoryToDelete(null);
    } catch (error) {
      setError('Failed to delete category');
    }
  };

  const handleDeleteCancel = () => {
    setDeleteDialogOpen(false);
    setCategoryToDelete(null);
  };

  const columns = [
    {
      key: 'name',
      label: 'Name',
      render: (item) => (
        <div className="text-gray-900 font-medium">{item.name}</div>
      )
    },
    {
      key: 'description',
      label: 'Description',
      render: (item) => (
        <div className="text-gray-500">{item.description}</div>
      )
    }
  ];

  if (loading) return <PageLoader />;

  const AddButton = (
    <button
      onClick={() => navigate('/admin/categories/create')}
      className="inline-flex items-center px-4 py-2 border border-transparent shadow-sm text-sm font-medium rounded-md text-white bg-primary-600 hover:bg-primary-700 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-primary-500"
    >
      <svg className="-ml-1 mr-2 h-5 w-5" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke="currentColor">
        <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M12 6v6m0 0v6m0-6h6m-6 0H6" />
      </svg>
      Add Category
    </button>
  );

  return (
    <div className="space-y-6">
      <PageHeader
        title="Categories"
        description="Manage your product categories"
        action={AddButton}
      />

      {error && (
        <div className="rounded-md bg-red-50 p-4">
          <div className="text-sm text-red-700">{error}</div>
        </div>
      )}

      <Card>
        <Table
          columns={columns}
          data={categories}
          onEdit={handleEdit}
          onDelete={handleDeleteClick}
        />
      </Card>

      <ConfirmDialog
        isOpen={deleteDialogOpen}
        title="Delete Category"
        message={`Are you sure you want to delete "${categoryToDelete?.name}"? This will also delete all subcategories and products in this category.`}
        onConfirm={handleDeleteConfirm}
        onCancel={handleDeleteCancel}
      />
    </div>
  );
};

export default Categories;