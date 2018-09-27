package com.main.java.bsu.sorts.main;

import com.main.java.bsu.sorts.*;
import com.main.java.bsu.sorts.main.RandomGenerator;

public class Runner {
    public Runner() {
        InsertionSort insertionSort = new InsertionSort();
        MergeSort mergeSort = new MergeSort();
        QuickSort quickSort = new QuickSort();
        CountingSort countSort = new CountingSort();
        QuickWithInsertionSort quickWithInsertionSort = new QuickWithInsertionSort();

        int[] arr = new RandomGenerator(2000).getArray();

        long startTime = System.currentTimeMillis();

//        insertionSort.insertionSort(arr);
//        countSort.countSort(arr);
//        mergeSort.mergeSort(arr, 0, arr.length - 1);
//        quickSort.quickSort(arr, 0, arr.length - 1);
        quickWithInsertionSort.quickWithInsertionSort(arr, 0, arr.length - 1);

        long endTime = System.currentTimeMillis();

        System.out.println("\nTotal time spent: " + (endTime - startTime) + " ms.");
    }
}

