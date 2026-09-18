// 04. 객체지향: 클래스, 상속, 추상 클래스, 인터페이스, 다형성
import java.util.ArrayList;
import java.util.List;

interface Drawable {
    void draw();
}

abstract class Shape implements Drawable {
    protected String name;

    public Shape(String name) {
        this.name = name;
    }

    public abstract double area();

    public String getName() {
        return name;
    }

    @Override
    public void draw() {
        System.out.println(name + " 그리기 (넓이: " + String.format("%.2f", area()) + ")");
    }
}

class Circle extends Shape {
    private double radius;

    public Circle(double radius) {
        super("원");
        this.radius = radius;
    }

    @Override
    public double area() {
        return Math.PI * radius * radius;
    }
}

class Rectangle extends Shape {
    private double width, height;

    public Rectangle(double width, double height) {
        super("직사각형");
        this.width = width;
        this.height = height;
    }

    @Override
    public double area() {
        return width * height;
    }
}

class Square extends Rectangle {
    public Square(double side) {
        super(side, side);
        this.name = "정사각형";
    }
}

class Triangle extends Shape {
    private double base, height;

    public Triangle(double base, double height) {
        super("삼각형");
        this.base = base;
        this.height = height;
    }

    @Override
    public double area() {
        return 0.5 * base * height;
    }
}

public class OopShapes {
    public static void main(String[] args) {
        List<Shape> shapes = new ArrayList<>();
        shapes.add(new Circle(3));
        shapes.add(new Rectangle(4, 5));
        shapes.add(new Square(4));
        shapes.add(new Triangle(6, 3));

        // 다형성: 부모 타입으로 자식 메서드 호출
        double totalArea = 0;
        for (Shape shape : shapes) {
            shape.draw();
            totalArea += shape.area();
        }
        System.out.println("전체 넓이: " + String.format("%.2f", totalArea));

        // instanceof 확인
        for (Shape shape : shapes) {
            if (shape instanceof Rectangle) {
                System.out.println(shape.getName() + "은(는) Rectangle의 자식입니다.");
            }
        }
    }
}
