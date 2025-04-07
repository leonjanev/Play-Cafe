const Video = () => {
  return (
    <div className="relative w-full h-[500px] overflow-hidden">
      <video
        className="absolute top-0 left-0 w-full h-full object-cover"
        autoPlay
        loop
        muted
        playsInline
      >
        <source
          src="src/assets/playcafe.mp4"
          type="video/mp4"
        />
        Your browser does not support the video tag.
      </video>
      <div className="absolute inset-0 bg-black bg-opacity-50">
        <div className="flex items-center justify-center h-full">
          <div className="text-center text-white">
            <h1 className="text-4xl font-bold mb-4">
              Welcome to <span className="text-primary-500">Play</span>
              <span className="text-secondary-500">Cafe</span>
            </h1>
            <p className="text-xl">Discover our amazing menu</p>
          </div>
        </div>
      </div>
    </div>
  );
};

export default Video; 