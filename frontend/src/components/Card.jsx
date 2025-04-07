const Card = ({ children, title, padding = "normal" }) => {
  const paddingClasses = {
    normal: "p-6",
    large: "p-8",
    small: "p-4"
  };

  return (
    <div className="bg-white rounded-lg shadow-xl overflow-hidden">
      {title && (
        <div className="px-6 py-4 border-b border-gray-200">
          <h2 className="text-lg font-semibold text-gray-800">{title}</h2>
        </div>
      )}
      <div className={paddingClasses[padding]}>
        {children}
      </div>
    </div>
  );
};

export default Card; 