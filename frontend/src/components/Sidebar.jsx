import { Link, useLocation } from 'react-router-dom';

const Sidebar = () => {
  const location = useLocation();
  
  const menuItems = [
    { path: '/products', label: 'Products' },
    { path: '/categories', label: 'Categories' },
    { path: '/subcategories', label: 'Subcategories' },
  ];

  return (
    <div className="w-64 flex-shrink-0 bg-gray-800 text-white">
      <div className="p-4">
        <h2 className="text-2xl font-bold">Admin Panel</h2>
      </div>
      <nav className="mt-4">
        {menuItems.map((item) => (
          <Link
            key={item.path}
            to={item.path}
            className={`block px-4 py-2 hover:bg-gray-700 ${
              location.pathname.startsWith(item.path) ? 'bg-gray-700' : ''
            }`}
          >
            {item.label}
          </Link>
        ))}
      </nav>
    </div>
  );
};

export default Sidebar;