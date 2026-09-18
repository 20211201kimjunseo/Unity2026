// 02. 제어문: if, switch, for, while, do-while, break/continue
public class ControlFlow {
    public static void main(String[] args) {
        // if-else
        int score = 85;
        if (score >= 90) {
            System.out.println("A");
        } else if (score >= 80) {
            System.out.println("B");
        } else if (score >= 70) {
            System.out.println("C");
        } else {
            System.out.println("F");
        }

        // switch (화살표 문법)
        int day = 3;
        String dayName = switch (day) {
            case 1 -> "월요일";
            case 2 -> "화요일";
            case 3 -> "수요일";
            case 4 -> "목요일";
            case 5 -> "금요일";
            default -> "주말";
        };
        System.out.println("오늘은 " + dayName);

        // for: 1부터 10까지 합
        int sum = 0;
        for (int i = 1; i <= 10; i++) {
            sum += i;
        }
        System.out.println("1~10 합: " + sum);

        // 구구단 2단
        for (int i = 1; i <= 9; i++) {
            System.out.println("2 x " + i + " = " + (2 * i));
        }

        // while: 1000을 넘는 첫 2의 거듭제곱
        int power = 1;
        while (power < 1000) {
            power *= 2;
        }
        System.out.println("1000을 넘는 첫 2의 거듭제곱: " + power);

        // do-while
        int n = 0;
        do {
            System.out.println("do-while 실행 " + n);
            n++;
        } while (n < 3);

        // break / continue: 홀수만 출력, 7 이후 중단
        for (int i = 1; i <= 10; i++) {
            if (i % 2 == 0) continue;
            if (i > 7) break;
            System.out.print(i + " ");
        }
        System.out.println();

        // 중첩 반복문: 별 삼각형
        for (int i = 1; i <= 5; i++) {
            for (int j = 0; j < i; j++) {
                System.out.print("*");
            }
            System.out.println();
        }
    }
}
