import { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { createCategory } from '../../../services/api';

const CreateCategory = () => {
  const navigate = useNavigate();
  const [formData, setFormData] = useState({ name: '', description: '' });

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      await createCategory(formData);
      navigate('/admin/categories');
    } catch (error) {
      console.error('Error creating category:', error);
    }
  };

  return (
    <div className="max-w-2xl mx-auto">
      <h1 className="text-2xl font-semibold mb-6">Create Category</h1>
      <form onSubmit={handleSubmit} className="space-y-4">
        <div>
          <label className="block text-sm font-medium text-gray-700">Name</label>
          <input
            type="text"
            value={formData.name}
            onChange={(e) => setFormData({ ...formData, name: e.target.value })}
            className="mt-1 block w-full rounded-md border-gray-300 shadow-sm"
            required
          />
        </div>
        <div>
          <label className="block text-sm font-medium text-gray-700">Description</label>
          <textarea
            value={formData.description}
            onChange={(e) => setFormData({ ...formData, description: e.target.value })}
            className="mt-1 block w-full rounded-md border-gray-300 shadow-sm"
          />
        </div>
        <div className="flex justify-end space-x-4">
          <button type="button" onClick={() => navigate('/admin/categories')} className="px-4 py-2 text-gray-700 bg-gray-100 rounded-md hover:bg-gray-200">Cancel</button>
          <button type="submit" className="px-4 py-2 text-white bg-blue-500 rounded-md hover:bg-blue-600">Create</button>
        </div>
      </form>
    </div>
  );
};

export default CreateCategory;