const PageHeader = ({ title, description, action }) => {
  return (
    <div className="mb-8">
      <div className="sm:flex sm:items-center sm:justify-between">
        <div>
          <h1 className="text-2xl font-bold text-gray-900">{title}</h1>
          {description && (
            <p className="mt-2 text-sm text-gray-700">{description}</p>
          )}
        </div>
        {action && (
          <div className="mt-4 sm:mt-0">
            {action}
          </div>
        )}
      </div>
    </div>
  );
};

export default PageHeader; 