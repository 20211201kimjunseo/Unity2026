// 03. 배열과 컬렉션: 배열, 2차원 배열, ArrayList, HashMap, 정렬
import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

public class ArraysAndCollections {
    public static void main(String[] args) {
        // 1차원 배열
        int[] numbers = {5, 3, 8, 1, 9, 2};
        System.out.println("배열: " + Arrays.toString(numbers));

        int max = numbers[0];
        int total = 0;
        for (int num : numbers) {
            if (num > max) max = num;
            total += num;
        }
        System.out.println("최댓값: " + max);
        System.out.println("합계: " + total);
        System.out.println("평균: " + (double) total / numbers.length);

        Arrays.sort(numbers);
        System.out.println("정렬 후: " + Arrays.toString(numbers));

        // 2차원 배열
        int[][] matrix = {
            {1, 2, 3},
            {4, 5, 6},
            {7, 8, 9}
        };
        System.out.println("2차원 배열:");
        for (int[] row : matrix) {
            for (int value : row) {
                System.out.print(value + " ");
            }
            System.out.println();
        }

        // ArrayList
        List<String> fruits = new ArrayList<>();
        fruits.add("사과");
        fruits.add("바나나");
        fruits.add("포도");
        fruits.add("딸기");
        System.out.println("과일 목록: " + fruits);
        System.out.println("크기: " + fruits.size());
        System.out.println("첫 번째: " + fruits.get(0));

        fruits.remove("바나나");
        System.out.println("바나나 제거 후: " + fruits);
        System.out.println("포도 포함? " + fruits.contains("포도"));

        // HashMap
        Map<String, Integer> scores = new HashMap<>();
        scores.put("국어", 90);
        scores.put("수학", 85);
        scores.put("영어", 95);

        for (Map.Entry<String, Integer> entry : scores.entrySet()) {
            System.out.println(entry.getKey() + ": " + entry.getValue() + "점");
        }

        int sum = 0;
        for (int score : scores.values()) sum += score;
        System.out.println("평균 점수: " + (double) sum / scores.size());
    }
}
