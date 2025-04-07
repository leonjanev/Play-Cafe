import { Link, useNavigate, useLocation } from 'react-router-dom';
import { logout } from '../../services/auth';

const AdminLayout = ({ children }) => {
  const navigate = useNavigate();
  const location = useLocation();

  const isActivePath = (path) => {
    return location.pathname.startsWith(path);
  };

  const handleLogout = () => {
    logout();
    navigate('/login');
  };

  return (
    <div className="min-h-screen bg-gray-100">
      <nav className="bg-white shadow-lg">
        <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
          <div className="flex justify-between h-16">
            <div className="flex">
              <div className="flex-shrink-0 flex items-center">
                <Link to="/admin" className="text-xl font-bold">
                  <span className="text-primary-500">Play</span>
                  <span className="text-secondary-500">Cafe Admin</span>
                </Link>
              </div>
              <div className="hidden sm:ml-6 sm:flex sm:space-x-8">
                <Link
                  to="/admin/products"
                  className={`inline-flex items-center px-1 pt-1 text-sm font-medium ${
                    isActivePath('/admin/products')
                      ? 'border-b-2 border-primary-500 text-primary-600'
                      : 'text-gray-900 hover:text-primary-600'
                  }`}
                >
                  Products
                </Link>
                <Link
                  to="/admin/categories"
                  className={`inline-flex items-center px-1 pt-1 text-sm font-medium ${
                    isActivePath('/admin/categories')
                      ? 'border-b-2 border-primary-500 text-primary-600'
                      : 'text-gray-900 hover:text-primary-600'
                  }`}
                >
                  Categories
                </Link>
                <Link
                  to="/admin/subcategories"
                  className={`inline-flex items-center px-1 pt-1 text-sm font-medium ${
                    isActivePath('/admin/subcategories')
                      ? 'border-b-2 border-primary-500 text-primary-600'
                      : 'text-gray-900 hover:text-primary-600'
                  }`}
                >
                  Subcategories
                </Link>
              </div>
            </div>
            <div className="flex items-center">
              <button
                onClick={handleLogout}
                className="ml-4 inline-flex items-center px-4 py-2 border border-transparent text-sm font-medium rounded-md text-white bg-primary-500 hover:bg-primary-600"
              >
                Logout
              </button>
            </div>
          </div>
        </div>
      </nav>

      <main className="max-w-7xl mx-auto py-6 px-4 sm:px-6 lg:px-8">
        {children}
      </main>
    </div>
  );
};

export default AdminLayout; 