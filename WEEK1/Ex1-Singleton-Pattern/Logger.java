
public class Logger {

    // 1. Static variable to hold the single instance
    private static Logger instance;

    // 2. Private constructor to prevent instantiation from other classes
    private Logger() {
        System.out.println("Logger instance created.");
    }

    // 3. Public static method to get the instance (Lazy initialization)
    public static Logger getInstance() {
        if (instance == null) {
            instance = new Logger();
        }
        return instance;
    }

    // 4. Method to simulate logging
    public void log(String message) {
        System.out.println("[LOG] " + message);
    }
}
