
public class Main {
    public static void main(String[] args) {
        // Get Logger instance
        Logger logger1 = Logger.getInstance();
        Logger logger2 = Logger.getInstance();

        // Use the logger
        logger1.log("This is the first log message.");
        logger2.log("This is the second log message.");

        // Check if both instances are the same
        if (logger1 == logger2) {
            System.out.println("Only one instance exists. Singleton works!");
        } else {
            System.out.println("Different instances exist. Singleton failed!");
        }
    }
}
