import Sidebar from './Sidebar';

const Layout = ({ children }) => {
  return (
    <div className="flex min-h-screen">
      <Sidebar />
      <div className="flex-1 bg-gray-100">
        <header className="bg-white shadow-sm sticky top-0 z-10">
          <div className="px-8 py-6">
            <h1 className="text-2xl font-bold text-gray-900">Admin Dashboard</h1>
          </div>
        </header>
        <main className="p-8">
          <div className="w-full">
            {children}
          </div>
        </main>
      </div>
    </div>
  );
};

export default Layout;