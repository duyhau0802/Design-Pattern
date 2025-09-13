# Prototype Pattern

- Muốn sao chép đối tượng phức tạp

## Vấn đề

- Không thể sao chép các member private
- Phải biết chính xác class cụ thể để tạo bản sao

## Giải pháp

- Prototype pattern : giao việc clone đối tượng cho chính đối tượng đó
  -> Có thể clone ko phụ thuộc vào class cụ thể, copy được các member private

- Khi cần tạo nhiều đối tượng giống nhau nhưng có thể thay đổi một vài thuộc tính. dùng CopyWith
- Cần phân biệt DeepClone vs ShallowClone
- CopyWith : là method thường thấy trong các class imutable (bất biến), dùng để copy đồng thời thay đổi 1 số trường

---

# CopyHeroPrototype

- dùng prototype với deepcopy method để copy class Hero với nhiều members và 1 field với type động (class item)
