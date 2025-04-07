import { useState, useEffect } from 'react';
import { useNavigate, useParams } from 'react-router-dom';
import { updateCategory, fetchCategoryById } from '../../../services/api';
import { PageLoader } from '../../../components/Loading';
import Card from '../../../components/Card';

const EditCategory = () => {
  const { id } = useParams();
  const navigate = useNavigate();
  const [formData, setFormData] = useState({
    name: '',
    description: ''
  });
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  useEffect(() => {
    const loadCategory = async () => {
      try {
        const categoryData = await fetchCategoryById(id);
        setFormData({
          name: categoryData.name,
          description: categoryData.description
        });
      } catch (error) {
        console.error('Error fetching category:', error);
        setError('Failed to load category');
      } finally {
        setLoading(false);
      }
    };
    loadCategory();
  }, [id]);

  const handleSubmit = async (e) => {
    e.preventDefault();
    setLoading(true);
    setError(null);
    try {
      await updateCategory(id, formData);
      navigate('/admin/categories');
    } catch (error) {
      setError(error.response?.data?.title || 'Failed to update category');
    } finally {
      setLoading(false);
    }
  };

  if (loading) return <PageLoader />;

  return (
    <Card title="Edit Category">
      {error && (
        <div className="mb-6 p-4 bg-red-50 border border-red-200 text-red-600 rounded-md">
          {error}
        </div>
      )}

      <form onSubmit={handleSubmit} className="space-y-6">
        <div>
          <label className="block text-sm font-medium text-gray-700">Name</label>
          <input
            type="text"
            value={formData.name}
            onChange={(e) => setFormData({ ...formData, name: e.target.value })}
            className="mt-1 block w-full rounded-md border-gray-300 shadow-sm focus:border-primary-500 focus:ring-primary-500 sm:text-sm"
            required
          />
        </div>

        <div>
          <label className="block text-sm font-medium text-gray-700">Description</label>
          <textarea
            value={formData.description}
            onChange={(e) => setFormData({ ...formData, description: e.target.value })}
            rows={3}
            className="mt-1 block w-full rounded-md border-gray-300 shadow-sm focus:border-primary-500 focus:ring-primary-500 sm:text-sm"
          />
        </div>

        <div className="flex justify-end space-x-4 pt-4">
          <button
            type="button"
            onClick={() => navigate('/admin/categories')}
            className="px-4 py-2 text-sm font-medium text-gray-700 bg-white border border-gray-300 rounded-md hover:bg-gray-50 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-primary-500"
          >
            Cancel
          </button>
          <button
            type="submit"
            className="px-4 py-2 text-sm font-medium text-white bg-primary-600 border border-transparent rounded-md hover:bg-primary-700 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-primary-500"
            disabled={loading}
          >
            {loading ? 'Updating...' : 'Update'}
          </button>
        </div>
      </form>
    </Card>
  );
};

export default EditCategory;