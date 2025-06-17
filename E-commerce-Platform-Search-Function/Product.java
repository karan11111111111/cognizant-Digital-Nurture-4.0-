public class Product {
    int productId;
    String productName;
    String category;

    public Product(int productId, String productName, String category) {
        this.productId = productId;
        this.productName = productName;
        this.category = category;
    }

    @Override
    public String toString() {
        return "Product{" +
                "ID=" + productId +
                ", Name='" + productName + '\'' +
                ", Category='" + category + '\'' +
                '}';
    }

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

}

