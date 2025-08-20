# 📘 JavaScript - Variables, Datatypes and Scope

## 1. How to Run JavaScript

### In the Browser Console

```js
console.log("Hello, World!");
```

### In an HTML File

```html
<!DOCTYPE html>
<html>
<head>
  <title>My First JS</title>
</head>
<body>
  <h1>Hello!</h1>
  <script>
    console.log("Hello from JavaScript inside HTML!");
  </script>
</body>
</html>
```

---

## 2. Variables (`var`, `let`, `const`)

* **`var`** → function-scoped, can be re-declared and updated, leaks out of blocks.
* **`let`** → block-scoped, can be updated but not re-declared in same scope.
* **`const`** → block-scoped, cannot be reassigned (but object/array contents can change).

### Example:

```js
var city = "London";
let name = "Alice";
const age = 25;

name = "Bob";  // ✅ allowed
// age = 30;   // ❌ Error
```

---

## 3. Data Types

### Primitive

* **String**: `"Hello"`
* **Number**: `42`, `3.14`
* **Boolean**: `true`, `false`
* **Undefined**: declared but not assigned
* **Null**: intentional empty value
* **Symbol**: unique identifiers
* **BigInt**: large integers (`123456789n`)

### Non-Primitive

* **Object**: key-value pairs
* **Array**: ordered list

### Example:

```js
let username = "Bob";      // string
let score = 42;            // number
let isActive = true;       // boolean
let account = null;        // null
let notAssigned;           // undefined
let user = { id: 1 };      // object
let numbers = [1, 2, 3];   // array
```

---

## 4. `null` vs `undefined` vs `symbol`

### `null`

Intentional empty value.

```js
let car = null;
console.log(car); // null
```

### `undefined`

Variable declared but not assigned.

```js
let house;
console.log(house); // undefined
```

### `symbol`

Unique identifier.

```js
let id1 = Symbol("user");
let id2 = Symbol("user");
console.log(id1 === id2); // false
```

---

## 5. `typeof` Operator

```js
console.log(typeof "Hello");     // "string"
console.log(typeof 42);          // "number"
console.log(typeof true);        // "boolean"
console.log(typeof undefined);   // "undefined"
console.log(typeof null);        // "object" (quirk in JS)
console.log(typeof {});          // "object"
console.log(typeof []);          // "object" (use Array.isArray() to check arrays)
console.log(typeof function(){}); // "function"
console.log(typeof Symbol());    // "symbol"
console.log(typeof 123n);        // "bigint"
```

---

## 6. Hoisting

```js
console.log(a); // undefined
var a = 10;

console.log(b); // ReferenceError
let b = 20;

console.log(c); // ReferenceError
const c = 30;
```

---

## 7. Const with Objects

```js
const user = { name: "Alice" };
user.name = "Bob";  // ✅ allowed
// user = { name: "Charlie" }; ❌ Error
```

---

## 8. Dynamic Typing

JavaScript variables can change type at runtime.

```js
let data = 42; 
console.log(typeof data); // "number"

data = "Hello";
console.log(typeof data); // "string"

data = true;
console.log(typeof data); // "boolean"
```

---

## 9. Scoping

### Global, Function, Block

```js
var a = 10; // global

if (true) {
  let b = 20; // block
  const c = 30; // block
}
function test() {
  var d = 40; // function scope
}
```

### `var` vs `let` in Loops

```js
for (var i = 0; i < 3; i++) {
  setTimeout(() => console.log("var:", i), 1000);
}
// Output: var: 3, var: 3, var: 3

for (let j = 0; j < 3; j++) {
  setTimeout(() => console.log("let:", j), 1000);
}
// Output: let: 0, let: 1, let: 2
```

### Shadowing

```js
let value = 100;
function demo() {
  let value = 200; // shadows outer variable
  console.log(value); // 200
}
demo();
console.log(value); // 100
```

### Lexical Scope & Closures

```js
function outer() {
  let name = "Alice";
  function inner() {
    console.log("Hello, " + name);
  }
  return inner;
}
let greet = outer();
greet(); // "Hello, Alice"
```

---

# ✅ Summary

* Use **`let`** (changeable) and **`const`** (constant) instead of `var`.
* Know the difference between **primitive** and **non-primitive** data types.
* Be aware of quirks (`typeof null` → `"object"`, arrays are objects).
* Hoisting: `var` is initialized as `undefined`; `let` and `const` are in temporal dead zone.
* Scope:

  * `var` → function scope.
  * `let` & `const` → block scope.
  * Functions create new scope.
  * Inner functions remember outer variables → **closures**.

---

