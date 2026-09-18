// 05. 종합 실습: 학생 성적 관리 (레코드, 스트림, 예외 처리, 문자열 처리)
import java.util.ArrayList;
import java.util.Comparator;
import java.util.List;
import java.util.stream.Collectors;

record Student(String name, int korean, int math, int english) {
    int total() {
        return korean + math + english;
    }

    double average() {
        return total() / 3.0;
    }

    String grade() {
        double avg = average();
        if (avg >= 90) return "A";
        if (avg >= 80) return "B";
        if (avg >= 70) return "C";
        return "F";
    }
}

class InvalidScoreException extends Exception {
    public InvalidScoreException(String message) {
        super(message);
    }
}

public class StudentManager {
    private final List<Student> students = new ArrayList<>();

    public void add(String name, int korean, int math, int english) throws InvalidScoreException {
        for (int score : new int[]{korean, math, english}) {
            if (score < 0 || score > 100) {
                throw new InvalidScoreException(name + ": 점수는 0~100 사이여야 합니다. (입력값: " + score + ")");
            }
        }
        students.add(new Student(name, korean, math, english));
    }

    public void printAll() {
        System.out.println("이름\t국어\t수학\t영어\t총점\t평균\t등급");
        System.out.println("-".repeat(56));
        for (Student s : students) {
            System.out.printf("%s\t%d\t%d\t%d\t%d\t%.1f\t%s%n",
                    s.name(), s.korean(), s.math(), s.english(),
                    s.total(), s.average(), s.grade());
        }
    }

    public void printRanking() {
        System.out.println("\n[총점 순위]");
        List<Student> sorted = students.stream()
                .sorted(Comparator.comparingInt(Student::total).reversed())
                .toList();
        int rank = 1;
        for (Student s : sorted) {
            System.out.println(rank++ + "위: " + s.name() + " (" + s.total() + "점)");
        }
    }

    public void printStats() {
        double classAvg = students.stream()
                .mapToDouble(Student::average)
                .average()
                .orElse(0);
        System.out.printf("%n반 평균: %.2f%n", classAvg);

        List<String> honors = students.stream()
                .filter(s -> s.grade().equals("A"))
                .map(Student::name)
                .collect(Collectors.toList());
        System.out.println("A등급 학생: " + (honors.isEmpty() ? "없음" : String.join(", ", honors)));

        Student top = students.stream()
                .max(Comparator.comparingInt(Student::math))
                .orElseThrow();
        System.out.println("수학 1등: " + top.name() + " (" + top.math() + "점)");
    }

    public static void main(String[] args) {
        StudentManager manager = new StudentManager();

        String[][] rawData = {
            {"김준서", "92", "88", "95"},
            {"이영희", "78", "85", "80"},
            {"박민수", "65", "70", "72"},
            {"최지우", "99", "95", "97"},
            {"정우성", "85", "120", "90"}   // 잘못된 점수 -> 예외 발생
        };

        for (String[] row : rawData) {
            try {
                manager.add(row[0],
                        Integer.parseInt(row[1]),
                        Integer.parseInt(row[2]),
                        Integer.parseInt(row[3]));
            } catch (InvalidScoreException e) {
                System.out.println("[오류] " + e.getMessage());
            } catch (NumberFormatException e) {
                System.out.println("[오류] 숫자 형식이 잘못되었습니다: " + e.getMessage());
            }
        }

        System.out.println();
        manager.printAll();
        manager.printRanking();
        manager.printStats();
    }
}
