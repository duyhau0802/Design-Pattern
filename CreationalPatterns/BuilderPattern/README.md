## 🍕 Pizza Builder — README

### 📝 Bài toán

Chúng ta cần xây dựng một hệ thống đặt pizza online, cho phép khách hàng tuỳ chọn nhiều thành phần (topping), kích thước, viền bánh, sốt, v.v.

Ví dụ khách hàng có thể chọn:
Kích thước: Small / Medium / Large
Viền phô mai, viền xúc xích
Topping: pepperoni, mushroom, olive, onion, v.v.
Sốt: BBQ / Tomato / Spicy
Tuỳ chọn chay hoặc cay
Mỗi khách hàng có thể chọn khác nhau, và có thể không chọn tất cả các thành phần.

---

### ⚠️ Bất cập khi dùng Constructor truyền thống

Cách đầu tiên dễ nghĩ đến là dùng constructor truyền thống:

```csharp
public class Pizza
{
public Pizza(string size, bool cheeseCrust, bool sausageCrust,
bool pepperoni, bool mushroom, bool olive, string sauce)
{
...
}
}
```

Nhưng cách này có những vấn đề:
Tham số quá nhiều → dễ nhầm lẫn khi truyền vào (bug tiềm ẩn)
Nhiều tham số không bắt buộc → phải truyền null hoặc false thừa
Khó đọc, khó mở rộng (thêm topping mới sẽ phải thêm tham số → sửa constructor, ảnh hưởng mọi nơi gọi)

### Giải pháp: Builder Pattern

Builder Pattern giúp:
Dễ đọc và rõ nghĩa khi tạo object phức tạp
Linh hoạt: chỉ set những gì cần thiết
Dễ mở rộng thêm thuộc tính mới mà không ảnh hưởng code cũ
Có thể thêm một lớp Director để định nghĩa các cấu hình sẵn (ví dụ pizza chay, pizza cay)

---

### 🧩 Vai trò của Director trong Builder Pattern

Trong Builder Pattern, ngoài 2 vai chính là:
Product (đối tượng phức tạp cần tạo ra — ở đây là Pizza)
Builder (xây dựng từng phần cho Product)
thì thường có một lớp thứ ba là Director đóng vai trò điều khiển quá trình xây dựng.

🎯 Mục đích của Director
Gom các bước xây dựng lại thành các công thức chuẩn
Tái sử dụng logic tạo object nhiều lần, tránh lặp lại code builder rải rác khắp nơi
Giúp client không phải biết chi tiết cách tạo từng thành phần
