public class KLargestFinder {
    private int[] buffer;
    private int size;

    public KLargestFinder(int k) {
        this.buffer = new int[k];
        for (int i = 0; i < k; ++i) {
            this.buffer[i] = Integer.MIN_VALUE;
        }
        size = 0;
    }

    public void insertOneMore(int a) {
        int insertionIndex = findInsertionPoint(buffer, 0, size, a);
    }

    private int findInsertionPoint(int[] buffer, int from, int to, int key) {
        int lo = from;
        int hi = to;

        while (lo <= hi) {
            int mid = lo + (hi - lo) / 2;
            if      (key < buffer[mid]) {lo = mid + 1;}
            else if (key > buffer[mid]) {hi = mid - 1;}
            else return mid;
        }

        return
    }
}
