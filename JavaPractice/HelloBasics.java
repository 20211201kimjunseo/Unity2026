// 01. 자바 기초: 변수, 자료형, 연산자, 형변환
public class HelloBasics {
    public static void main(String[] args) {
        System.out.println("Hello, Java!");

        // 기본 자료형
        int age = 24;
        double height = 175.5;
        char grade = 'A';
        boolean isStudent = true;
        String name = "김준서";

        System.out.println("이름: " + name);
        System.out.println("나이: " + age);
        System.out.println("키: " + height);
        System.out.println("학점: " + grade);
        System.out.println("학생 여부: " + isStudent);

        // 산술 연산
        int a = 17, b = 5;
        System.out.println("a + b = " + (a + b));
        System.out.println("a - b = " + (a - b));
        System.out.println("a * b = " + (a * b));
        System.out.println("a / b = " + (a / b));   // 정수 나눗셈
        System.out.println("a % b = " + (a % b));

        // 형변환
        double result = (double) a / b;
        System.out.println("(double) a / b = " + result);
        int truncated = (int) 3.99;
        System.out.println("(int) 3.99 = " + truncated);

        // 증감 연산자
        int count = 0;
        count++;
        ++count;
        System.out.println("count = " + count);

        // 삼항 연산자
        String label = (age >= 20) ? "성인" : "미성년자";
        System.out.println(name + "은(는) " + label);
    }
}
