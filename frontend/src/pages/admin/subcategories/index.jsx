import { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import Table from '../../../components/Table';
import { PageLoader } from '../../../components/Loading';
import PageHeader from '../../../components/PageHeader';
import Card from '../../../components/Card';
import ConfirmDialog from '../../../components/ConfirmDialog';
import { fetchSubcategories, deleteSubcategory, fetchCategories } from '../../../services/api';

const Subcategories = () => {
  const navigate = useNavigate();
  const [subcategories, setSubcategories] = useState([]);
  const [categories, setCategories] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);
  const [deleteDialogOpen, setDeleteDialogOpen] = useState(false);
  const [subcategoryToDelete, setSubcategoryToDelete] = useState(null);

  useEffect(() => {
    const loadData = async () => {
      try {
        const [subcategoriesData, categoriesData] = await Promise.all([
          fetchSubcategories(),
          fetchCategories()
        ]);
        setSubcategories(subcategoriesData);
        setCategories(categoriesData);
      } catch (error) {
        setError('Failed to load data');
      } finally {
        setLoading(false);
      }
    };
    loadData();
  }, []);

  const getCategoryName = (categoryId) => {
    const category = categories.find(c => c.id === categoryId);
    return category ? category.name : 'N/A';
  };

  const handleEdit = (subcategory) => {
    navigate(`/admin/subcategories/edit/${subcategory.id}`);
  };

  const handleDeleteClick = (subcategory) => {
    setSubcategoryToDelete(subcategory);
    setDeleteDialogOpen(true);
  };

  const handleDeleteConfirm = async () => {
    try {
      await deleteSubcategory(subcategoryToDelete.id);
      setSubcategories(subcategories.filter(s => s.id !== subcategoryToDelete.id));
      setDeleteDialogOpen(false);
      setSubcategoryToDelete(null);
    } catch (error) {
      setError('Failed to delete subcategory');
    }
  };

  const handleDeleteCancel = () => {
    setDeleteDialogOpen(false);
    setSubcategoryToDelete(null);
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
      key: 'categoryId',
      label: 'Category',
      render: (item) => (
        <div className="text-gray-500">{getCategoryName(item.categoryId)}</div>
      )
    }
  ];

  if (loading) return <PageLoader />;

  const AddButton = (
    <button
      onClick={() => navigate('/admin/subcategories/create')}
      className="inline-flex items-center px-4 py-2 border border-transparent shadow-sm text-sm font-medium rounded-md text-white bg-primary-600 hover:bg-primary-700 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-primary-500"
    >
      <svg className="-ml-1 mr-2 h-5 w-5" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke="currentColor">
        <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M12 6v6m0 0v6m0-6h6m-6 0H6" />
      </svg>
      Add Subcategory
    </button>
  );

  return (
    <div className="space-y-6">
      <PageHeader
        title="Subcategories"
        description="Manage your product subcategories"
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
          data={subcategories}
          onEdit={handleEdit}
          onDelete={handleDeleteClick}
        />
      </Card>

      <ConfirmDialog
        isOpen={deleteDialogOpen}
        title="Delete Subcategory"
        message={`Are you sure you want to delete "${subcategoryToDelete?.name}"? This will also delete all products in this subcategory.`}
        onConfirm={handleDeleteConfirm}
        onCancel={handleDeleteCancel}
      />
    </div>
  );
};

export default Subcategories;