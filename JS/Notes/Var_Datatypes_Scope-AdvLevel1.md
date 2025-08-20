scopes are *the* backbone of how JavaScript variables live, behave, and die.
Let’s go deeper into **Global, Function, Block, Local, and Lexical Scope** with examples and tricky cases.

---

# 🔹 1. Global Scope

* A variable declared **outside any function or block** is in the **global scope**.
* Accessible anywhere in the program.
* In the browser → globals live in the `window` object.
* In Node.js → they live in `global`.

```js
var x = 10;   // global
let y = 20;   // global
const z = 30; // global

console.log(x, y, z); // 10 20 30

function demo() {
  console.log(x); // ✅ can access global variable
}
demo();
```

⚠️ Overusing global variables is bad → they can cause naming conflicts.

---

# 🔹 2. Function Scope

* Variables declared with `var`, `let`, or `const` inside a function **exist only inside that function**.

```js
function test() {
  var a = 1;
  let b = 2;
  const c = 3;
  console.log(a, b, c); // 1 2 3
}
test();

console.log(a); // ❌ ReferenceError
```

👉 Important:

* `var` is **function-scoped**, not block-scoped.
* `let` and `const` are **block-scoped** inside the function too.

---

# 🔹 3. Block Scope

* Blocks are `{ ... }` (if, for, while, etc).
* `let` and `const` respect block scope.
* `var` does **not** respect block scope.

```js
if (true) {
  var a = 100;
  let b = 200;
  const c = 300;
}

console.log(a); // ✅ 100 (leaks out)
// console.log(b); ❌ ReferenceError
// console.log(c); ❌ ReferenceError
```

---

# 🔹 4. Local Scope

* A **general term** for any variable declared inside a block or function (not global).
* Includes both function scope and block scope.

Example:

```js
function greet() {
  let msg = "Hello";
  if (true) {
    let name = "Alice";
    console.log(msg, name); // ✅ accessible inside
  }
  // console.log(name); ❌ ReferenceError
}
greet();
```

---

# 🔹 5. Lexical Scope

* Functions are **lexically scoped** → they remember the environment in which they were created.
* Inner functions can access outer function’s variables.

```js
function outer() {
  let outerVar = "I am outer";

  function inner() {
    console.log(outerVar); // ✅ can access
  }

  inner();
}
outer();
```

Even if returned:

```js
function outer() {
  let count = 0;

  function inner() {
    count++;
    return count;
  }
  return inner;
}

let counter = outer();
console.log(counter()); // 1
console.log(counter()); // 2
```

👉 This is **closure** (inner function holding onto lexical scope).

---

# 🔹 6. Scope Chain

When JavaScript looks for a variable:

1. First checks **local scope** (inside the function/block).
2. If not found, goes to **outer scope**.
3. Keeps going outward until **global scope**.
4. If still not found → **ReferenceError**.

```js
let globalVar = "global";

function outer() {
  let outerVar = "outer";

  function inner() {
    let innerVar = "inner";
    console.log(innerVar);   // ✅ "inner"
    console.log(outerVar);   // ✅ "outer"
    console.log(globalVar);  // ✅ "global"
  }

  inner();
}
outer();
```

---

# 🔹 7. Hoisting and Temporal Dead Zone (TDZ)

* `var` is hoisted to the top of its scope → initialized as `undefined`.
* `let` and `const` are hoisted too, but in **Temporal Dead Zone** until execution reaches them.

```js
console.log(a); // undefined
var a = 10;

console.log(b); // ❌ ReferenceError (TDZ)
let b = 20;
```

---

# 🔹 8. Tricky Scoping Examples

### Example 1: `var` vs `let` in loops

```js
for (var i = 0; i < 3; i++) {
  setTimeout(() => console.log("var:", i), 1000);
}
// var: 3, var: 3, var: 3

for (let j = 0; j < 3; j++) {
  setTimeout(() => console.log("let:", j), 1000);
}
// let: 0, let: 1, let: 2
```

### Example 2: Shadowing

```js
let value = 100;

function test() {
  let value = 200; // shadows outer
  console.log(value); // 200
}
test();
console.log(value); // 100
```

### Example 3: Illegal Shadowing

```js
let a = 10;
{
  // var a = 20; ❌ SyntaxError (cannot redeclare with var in same scope chain)
}
```

---

# ✅ Scope Summary

* **Global scope** → everywhere in the program.
* **Function scope** → variables exist only inside a function.
* **Block scope** → variables exist only inside `{ }` (let/const).
* **Local scope** → general term for function or block scope.
* **Lexical scope** → inner functions can access outer function variables (closure).
* **Scope chain** → lookup starts from local → outer → global.

---
