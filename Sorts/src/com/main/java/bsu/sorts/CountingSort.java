package com.main.java.bsu.sorts;

public class CountingSort {
    public void countSort(int[] array) {
        int min, max = min = array[0];
        for (int i = 1; i < array.length; i++) {
            if (array[i] < min) {
                min = array[i];
            }
            if (array[i] > max) {
                max = array[i];
            }
        }
    }
    private void count(int[] array, int min, int max) {
        int[] count = new int[max - min + 1];
        for (int i = 0; i < array.length; i++) {
            count[array[i] - min]++;
        }
        int idx = 0;
        for (int i = 0; i < count.length; i++) {
            for (int j = 0; j < count[i]; j++) {
                array[idx++] = i + min;
            }
        }
    }
}

