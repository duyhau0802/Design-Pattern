# ☕ Decorator Pattern Example – Coffee

## 📌 Giới thiệu

**Decorator Pattern** cho phép bạn mở rộng hành vi của một object **mà không cần thay đổi code gốc** hoặc tạo ra quá nhiều subclass.  
Trong ví dụ này, ta xây dựng một hệ thống `Coffee` có thể thêm các thành phần như **Milk**, **Sugar**, ... theo cách linh hoạt.

---

## ⚡ Vấn đề (Problem)

Nếu không dùng Decorator, bạn sẽ phải tạo nhiều class cho từng loại coffee khác nhau:

- `MilkCoffee`
- `SugarCoffee`
- `MilkSugarCoffee`
- `CaramelMilkSugarCoffee`
- ...

Điều này dẫn đến hiện tượng **Class Explosion** (bùng nổ số lượng class), rất khó bảo trì và mở rộng.

---

## 💡 Giải pháp (Solution)

Sử dụng **Decorator Pattern**:

- Tạo interface chung `ICoffee`.
- Implement cơ bản `SimpleCoffee`.
- Các "topping" như `MilkDecorator`, `SugarDecorator` được thiết kế dưới dạng **wrapper** bao quanh `ICoffee`.
- Có thể **kết hợp động nhiều decorator** ở runtime mà không cần tạo class mới.

---

## 🛠️ Ví dụ Code

```csharp
ICoffee coffee = new SimpleCoffee();
coffee = new MilkDecorator(coffee);
coffee = new SugarDecorator(coffee);

Console.WriteLine($"{coffee.GetDescription()} - ${coffee.GetCost()}");

// Output: Simple Coffee, Milk, Sugar - $2.7

```

---

## ✅ Ưu điểm

- **Mở rộng linh hoạt**: dễ thêm tính năng mới mà không sửa code gốc.
- **Tránh class explosion**: không cần tạo quá nhiều subclass cho từng kết hợp.
- **Kết hợp động tại runtime**: người dùng chọn “topping” nào thì chỉ cần gói decorator tương ứng.
- **Tuân theo Open/Closed Principle**: mở rộng hành vi mà không thay đổi code có sẵn.

---

## ⚠️ Nhược điểm

- Tạo nhiều object wrapper có thể làm code khó debug hơn.
- Nếu lạm dụng có thể khiến luồng logic phức tạp (chuỗi decorator lồng nhau).

---

## 🌍 Ứng dụng thực tế

- **Coffee Shop App**: chọn topping động.
- **Middleware trong Web frameworks** (ASP.NET Core, Express.js).
- **I/O Streams trong Java / .NET** (ví dụ: `BufferedStream`, `GZipStream`).
