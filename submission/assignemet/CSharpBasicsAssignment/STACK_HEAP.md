# Part E — Stack & Heap

## Diagram 1 — After line 1

```csharp
Order o1 = new Order { OrderId = 1, CustomerName = "Ali" };
```

```text
        STACK                         HEAP
   +----------------+          +----------------------+
   | o1             |          | Order Object         |
   | Address: 0x100 |--------->| Address: 0x100       |
   +----------------+          | OrderId = 1          |
                               | CustomerName = "Ali" |
                               | IsPaid = false       |
                               | ... other fields     |
                               +----------------------+
```

**Explanation:** The `new` keyword creates an Order object on the heap, and `o1` stores its address.

## Diagram 2 — After line 2

```csharp
Order o2 = o1;
```

```text
        STACK                         HEAP
   +----------------+          +----------------------+
   | o1             |----+     | Order Object         |
   | Address: 0x100 |    |     | Address: 0x100       |
   +----------------+    +---->| OrderId = 1          |
                               | CustomerName = "Ali" |
   +----------------+    +---->| IsPaid = false       |
   | o2             |----+     | ... other fields     |
   | Address: 0x100 |          +----------------------+
   +----------------+
```

**Explanation:** `o2` receives the same address as `o1`, so both variables refer to the same object.

## Diagram 3 — After line 3

```csharp
o2.IsPaid = true;
```

```text
        STACK                         HEAP
   +----------------+          +----------------------+
   | o1             |----+     | Order Object         |
   | Address: 0x100 |    |     | Address: 0x100       |
   +----------------+    +---->| OrderId = 1          |
                               | CustomerName = "Ali" |
   +----------------+    +---->| IsPaid = true        |
   | o2             |----+     | ... other fields     |
   | Address: 0x100 |          +----------------------+
   +----------------+
```

**Explanation:** The object's `IsPaid` field changes to `true`, and both `o1` and `o2` see the updated value because they refer to the same object.

## What would be different with structs?

If `Order` were a struct instead of a class, assigning `Point p2 = p1;` would copy the values of `p1` into `p2`. Each variable would have its own independent copy, so changing `p2.X` would not change `p1.X`. The diagram would show two separate copies of the struct's data instead of two references pointing to the same object.
