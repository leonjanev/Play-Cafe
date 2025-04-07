const Loading = ({ size = "default" }) => {
  const sizeClasses = {
    small: "h-4 w-4 border-2",
    default: "h-8 w-8 border-3",
    large: "h-12 w-12 border-4"
  };

  return (
    <div className="flex flex-col items-center justify-center p-4">
      <div className={`${sizeClasses[size]} animate-spin rounded-full border-gray-300 border-t-primary-600`} />
      <span className="mt-2 text-sm text-gray-500">Loading...</span>
    </div>
  );
};

export const PageLoader = () => {
  return (
    <div className="min-h-[400px] flex items-center justify-center">
      <Loading size="large" />
    </div>
  );
};

export const TableLoader = () => {
  return (
    <div className="w-full bg-white rounded-lg shadow-xl p-8">
      <div className="animate-pulse space-y-4">
        <div className="h-4 bg-gray-200 rounded w-1/4"></div>
        <div className="space-y-3">
          <div className="h-4 bg-gray-200 rounded"></div>
          <div className="h-4 bg-gray-200 rounded w-5/6"></div>
          <div className="h-4 bg-gray-200 rounded w-4/6"></div>
        </div>
      </div>
    </div>
  );
};

export default Loading; 