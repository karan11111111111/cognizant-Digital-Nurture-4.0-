import java.util.Arrays;
import java.util.Comparator;


public class MainSearchEngine {


public static Product binarySearch(Product[] products, int targetId) {
    int left = 0;
    int right = products.length - 1;

    while (left <= right) {
        int mid = left + (right - left) / 2;

        if (products[mid].productId == targetId) {
            return products[mid];
        } else if (products[mid].productId < targetId) {
            left = mid + 1;
        } else {
            right = mid - 1;
        }
    }
    return null;
}

public static Product linearSearch(Product[] products, int targetId) {
    for (Product product : products) {
        if (product.productId == targetId) {
            return product;
        }
    }
    return null;
}

    public static void main(String[] args) {
        Product[] products = {
            new Product(3, "Laptop", "Electronics"),
            new Product(1, "Book", "Education"),
            new Product(5, "Phone", "Electronics"),
            new Product(2, "Chair", "Furniture"),
            new Product(4, "Shoes", "Fashion")
        };

        // Sort for Binary Search
        Arrays.sort(products, Comparator.comparingInt(p -> p.productId));

        // Linear Search
        Product result1 = linearSearch(products, 4);
        System.out.println("Linear Search Result: " + result1);

        // Binary Search
        Product result2 = binarySearch(products, 4);
        System.out.println("Binary Search Result: " + result2);
    }

    // (Paste search methods here)
}
