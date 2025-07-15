## Comprehensive CSS Assignment: Building and Styling a Dynamic Product Page

**Objective:** This assignment is designed to provide a complete hands-on experience with CSS. You will build and extensively style a detailed product page, applying inline, internal, and external CSS, mastering the box model, understanding element display, implementing advanced Flexbox layouts, utilizing diverse CSS selectors, and working with positioning properties for various HTML elements including navigation menus, images, text, tables, and form controls.

**Instructions:**

1.  **Create Two Files:**

      * `product-page.html` (for the HTML structure)
      * `style.css` (for your external CSS rules)

2.  **Link CSS:** Ensure your `product-page.html` file correctly links to your `style.css` file using the `<link>` tag in the `<head>` section.

### Part 1: HTML Structure (`product-page.html`)

Create the following comprehensive HTML structure.

```html
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Awesome Tech Gadget - Product Page</title>
    <link rel="stylesheet" href="style.css">
    <style>
        /* Task 1.2: Internal CSS here */
    </style>
</head>
<body>
    <header>
        <div class="logo">
            <a href="#">TechWonders</a>
        </div>
        <nav class="main-nav">
            <ul>
                <li><a href="#">Home</a></li>
                <li class="has-submenu">
                    <a href="#">Products</a>
                    <ul class="submenu">
                        <li><a href="#">Laptops</a></li>
                        <li><a href="#">Smartphones</a></li>
                        <li><a href="#">Accessories</a></li>
                    </ul>
                </li>
                <li><a href="#">About Us</a></li>
                <li><a href="#">Contact</a></li>
            </ul>
        </nav>
        <p style="color: darkblue; font-weight: bold;">Your one-stop shop for amazing gadgets!</p> </header>

    <main>
        <section class="product-hero">
            <h1 class="product-title">The Ultimate SmartWatch Pro</h1>
            <div class="product-image-container">
                <img src="https://via.placeholder.com/600x400?text=SmartWatch+Pro" alt="Awesome SmartWatch Pro" class="product-main-image">
                <span class="new-badge">NEW!</span>
            </div>
            <p class="product-tagline">Experience innovation on your wrist.</p>
        </section>

        <section class="product-description-section">
            <div class="description-content">
                <h2>Product Overview <span class="highlight">Unleash Your Potential</span></h2>
                <p>The <span class="product-name-span">SmartWatch Pro</span> redefines connectivity and fitness tracking. With its sleek design and powerful features, it's more than just a watch – it's your personal assistant, health coach, and communication hub.</p>
                <p>Key features include a vibrant AMOLED display, advanced heart rate monitoring, GPS, and a long-lasting battery. <br>Compatible with both iOS and Android devices.</p>
                
                <h3>Technical Specifications</h3>
                <div class="specs-table-container">
                    <table class="specs-table">
                        <thead>
                            <tr>
                                <th>Feature</th>
                                <th>Detail</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>Display</td>
                                <td>1.8" AMOLED</td>
                            </tr>
                            <tr>
                                <td>Battery Life</td>
                                <td>Up to 7 days</td>
                            </tr>
                            <tr>
                                <td>Water Resistance</td>
                                <td>5 ATM</td>
                            </tr>
                            <tr>
                                <td>Connectivity</td>
                                <td>Bluetooth 5.2, GPS</td>
                            </tr>
                            <tr>
                                <td>Sensors</td>
                                <td>Heart Rate, SpO2, Accelerometer</td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>

            <div class="call-to-action-sidebar">
                <h3>Ready to Order?</h3>
                <form action="#" method="post" class="order-form">
                    <div class="form-group">
                        <label for="color">Color:</label>
                        <select id="color" name="color">
                            <option value="black">Midnight Black</option>
                            <option value="silver">Space Silver</option>
                            <option value="rose">Rose Gold</option>
                        </select>
                    </div>
                    <div class="form-group">
                        <label for="warranty">Extended Warranty:</label>
                        <input type="checkbox" id="warranty" name="warranty">
                    </div>
                    <div class="form-group">
                        <label for="quantity">Quantity:</label>
                        <input type="number" id="quantity" name="quantity" min="1" value="1">
                    </div>
                    <div class="form-group">
                        <label for="delivery-date">Preferred Delivery Date:</label>
                        <input type="date" id="delivery-date" name="deliveryDate">
                    </div>
                    <button type="submit" class="buy-now-btn">Buy Now</button>
                    <button type="reset" class="clear-form-btn">Clear Form</button>
                </form>
                <p class="shipping-info">Free <span class="fast-delivery">express shipping</span> on all orders!</p>
            </div>
        </section>
    </main>

    <div class="promo-banner">
        <p>🔥 Special Promotion: Save $50 today!</p>
        <a href="#" class="learn-more-link">Learn More</a>
    </div>

    <footer>
        <p>&copy; 2025 TechWonders. All rights reserved.</p>
        <p>Contact us at <a href="mailto:info@techwonders.com">info@techwonders.com</a></p>
    </footer>
</body>
</html>
```

### Part 2: CSS Styling

Apply the following styles using `style.css` unless otherwise specified.

-----

#### **Task 1: CSS Application Methods**

1.  **Inline CSS (Hint: Look at the HTML `style` attribute):**

      * **Task:** Make the `p` tag inside the `header` (which says "Your one-stop shop...") have a `color` of `darkblue` and `font-weight: bold;`.
      * **Hint:** Add the `style` attribute directly to the `<p>` tag in your `product-page.html` file.

2.  **Internal/Page-level CSS (Hint: Use the `<style>` tag in the `<head>`):**

      * **Task:** Set the default `font-family` for the entire `body` to `'Segoe UI', Arial, sans-serif` and a `background-color` of `#f4f7f6`.
      * **Hint:** Add these rules within the `<style>` tags provided in the `<head>` of your `product-page.html` file.

3.  **External CSS (`style.css` - all subsequent tasks):**

      * **Task:** Confirm your `style.css` is linked correctly. Set the default `color` for all text in the `body` to `#333`. Also, set `margin: 0;` and `padding: 0;` for the `body` to remove default browser spacing.
      * **Hint:** Add `body { color: #333; margin: 0; padding: 0; }` to your `style.css`. This is where all your other CSS will go.

-----

#### **Task 2: Box Model Clarity (Margin, Padding, Borders)**

1.  **Global Resets & Container:**

      * **Task:** Apply `box-sizing: border-box;` to `*` (universal selector) and `::before`, `::after` pseudo-elements. This is a best practice.
      * **Hint:** `*, *::before, *::after { box-sizing: border-box; }`. This ensures padding and borders are included in an element's total width/height.
      * **Task:** Give the `main` element a `max-width` of `1200px` and set `margin: 20px auto;` to center it horizontally with vertical spacing.
      * **Hint:** `margin: auto;` on left/right centers block-level elements with a defined width.

2.  **Header and Footer Spacing:**

      * **Task:** Add `padding` of `15px 30px;` to both the `header` and `footer`. Give them a `background-color` of `#2c3e50` (dark blue) and `color: white;`.
      * **Hint:** Apply styles directly to the `header` and `footer` elements.

3.  **Section Spacing and Styling:**

      * **Task:** Give `.product-hero` and `.product-description-section` a `background-color` of `#fff`, `padding` of `30px`, `border-radius: 10px;`, and a subtle `box-shadow: 0 5px 15px rgba(0,0,0,0.1);`.
      * **Hint:** Group these selectors.

4.  **Form Elements in Sidebar:**

      * **Task:** Add `padding: 20px;` to the `.order-form` within the `.call-to-action-sidebar`. Give it a light border: `1px solid #eee;` and `border-radius: 8px;`.
      * **Hint:** Target `.order-form`.

-----

#### **Task 3: Display Elements (Block vs. Inline vs. Inline-Block)**

1.  **Navigation Links:**

      * **Task:** Make the `li` elements in `.main-nav ul` display inline-block to allow them to sit side-by-side while still being able to apply width/height/padding.
      * **Hint:** Use `.main-nav ul li { display: inline-block; }`.
      * **Task:** Make the `a` elements within `.main-nav ul li` `display: block;` and add `padding: 10px 15px;` so the clickable area covers the whole list item.
      * **Hint:** `.main-nav ul li a { display: block; padding: 10px 15px; }`.

2.  **Product Title and Tagline:**

      * **Task:** Ensure `h1.product-title` and `p.product-tagline` are block-level elements (they are by default, but confirm their behavior). Add `margin-bottom: 15px;`.
      * **Hint:** Observe the natural flow of block elements.

3.  **`<span>` Element Styling:**

      * **Task:** The `span.new-badge` should be an inline-block element. Give it `background-color: #ff5722;`, `color: white;`, `padding: 3px 8px;`, `border-radius: 5px;`, and `font-size: 0.8em;`.
      * **Hint:** `display: inline-block;` allows you to apply dimensions and padding/margin without forcing a new line.

4.  **Form Labels:**

      * **Task:** Make `label` elements in `.form-group` display `block` to push their corresponding input fields onto a new line.
      * **Hint:** Use `.form-group label { display: block; margin-bottom: 5px; }`.

-----

#### **Task 4: Form Controls Styling**

1.  **Input/Select/Textarea Basic Styles:**

      * **Task:** Style all `input[type="text"]`, `input[type="email"]`, `input[type="number"]`, `input[type="date"]`, `select`, and `textarea` elements within the `.order-form`:
          * `width: 100%;`
          * `padding: 10px;`
          * `margin-top: 5px;`
          * `margin-bottom: 15px;`
          * `border: 1px solid #ccc;`
          * `border-radius: 5px;`
          * `box-sizing: border-box;`
      * **Hint:** Group these selectors, possibly with `.order-form` as a parent selector.

2.  **Checkbox/Radio Alignment:**

      * **Task:** Ensure the checkbox (`#warranty`) and its label appear nicely aligned on one line.
      * **Hint:** The `label` after an `input[type="checkbox"]` should probably remain `display: inline-block;`.

3.  **Button Styling:**

      * **Task:** Style `.buy-now-btn` and `.clear-form-btn`:
          * `padding: 12px 25px;`
          * `border: none;`
          * `border-radius: 5px;`
          * `cursor: pointer;`
          * `font-size: 1em;`
          * `transition: background-color 0.3s ease;`
          * `.buy-now-btn`: `background-color: #ff9800; color: white; margin-right: 10px;`.
          * `.clear-form-btn`: `background-color: #9e9e9e; color: white;`.
          * Add a `:hover` effect for both buttons to slightly darken their `background-color`.
      * **Hint:** Use class selectors for the buttons.

-----

#### **Task 5: Table Styling (`.specs-table`)**

1.  **Table Container:**

      * **Task:** Give `.specs-table-container` some `margin-top` (e.g., `20px`) and `margin-bottom` (e.g., `20px`).
      * **Hint:** This div wraps the table to control its external spacing.

2.  **Basic Table Structure:**

      * **Task:** Set `width: 100%;` for `.specs-table`. Collapse table borders using `border-collapse: collapse;`.
      * **Hint:** Apply styles directly to the `.specs-table` class.

3.  **Table Headers and Cells:**

      * **Task:** Add `border: 1px solid #ddd;` and `padding: 12px;` to all `th` (table headers) and `td` (table data cells) within `.specs-table`.
      * **Hint:** Group the `th` and `td` selectors, nested under `.specs-table`.

4.  **Table Header Background:**

      * **Task:** Set `background-color: #f2f2f2;` and `text-align: left;` for `th` elements within `.specs-table`.
      * **Hint:** Select `.specs-table th`.

5.  **Zebra Striping (Odd Rows):**

      * **Task:** Apply a `background-color` of `#e0f2f7;` (light blue) to every *odd* row (`tr`) in the table body.
      * **Hint:** Use the `:nth-child(odd)` pseudo-class for `tr` within `tbody` (e.g., `.specs-table tbody tr:nth-child(odd) { background-color: #e0f2f7; }`).

6.  **Hover Effect on Table Rows:**

      * **Task:** When hovering over a `tr` in the table body, change its `background-color` to `#cce7f0;`.
      * **Hint:** Use `.specs-table tbody tr:hover`.

-----

#### **Task 6: Page Layout Related Changes (Advanced Flexbox)**

1.  **Header Layout:**

      * **Task:** Use Flexbox on the `header` element to align the `.logo`, `.main-nav`, and the inline-styled `p` tag.
          * Set `display: flex;`.
          * Use `align-items: center;` to vertically align items.
          * Use `justify-content: space-between;` to distribute space between them.
      * **Hint:** This will spread out the header elements.

2.  **Main Content Sections Layout:**

      * **Task:** Use Flexbox on the `main` element to arrange the `.product-hero` and `.product-description-section` vertically with some gap.
          * Set `display: flex;`.
          * Set `flex-direction: column;`.
          * Add `gap: 30px;`.
      * **Hint:** This ensures your main sections stack nicely.

3.  **Product Description Section Layout:**

      * **Task:** Use Flexbox on `.product-description-section` to arrange `description-content` and `call-to-action-sidebar` side-by-side.
          * Set `display: flex;`.
          * Add `gap: 30px;`.
          * Set `flex-wrap: wrap;` for responsiveness.
          * `description-content`: `flex: 3; min-width: 400px;`.
          * `call-to-action-sidebar`: `flex: 1; min-width: 280px; background-color: #f0f8ff; padding: 20px; border-radius: 8px;`.
      * **Hint:** Use `flex-grow`, `flex-shrink`, and `flex-basis` via the `flex` shorthand.

-----

#### **Task 7: Advanced Selectors**

1.  **Targeting Every Other Form Group (`:nth-of-type`)**:

      * **Task:** Give every second `.form-group` inside the `.order-form` a light gray background: `background-color: #fcfcfc;`.
      * **Hint:** Use `.order-form .form-group:nth-of-type(even) { background-color: #fcfcfc; }`.

2.  **Immediate Sibling (`+`):**

      * **Task:** Add `margin-top: 20px;` to any `p` element that *immediately follows* an `h2` element within the `.description-content`.
      * **Hint:** Use `.description-content h2 + p { margin-top: 20px; }`.

3.  **General Sibling (`~`):**

      * **Task:** Give all `p` elements that are siblings to the `.product-tagline` (i.e., any `p` that comes after `.product-tagline` in the same parent) a `font-style: italic;`. (Note: in current HTML structure, only `p` in `header` might apply. This is for selector demonstration.)
      * **Hint:** Use `.product-tagline ~ p { font-style: italic; }`. If you add another `p` after `.product-tagline` in `product-hero`, you'll see this in action.

4.  **Direct Children (`>`):**

      * **Task:** Style only the `li` elements that are *direct children* of `.main-nav ul`. Give them a `border-right: 1px solid rgba(255,255,255,0.2);`. (Exclude the last one).
      * **Hint:** Use `.main-nav ul > li { border-right: 1px solid rgba(255,255,255,0.2); }`. You'd typically use `:not(:last-child)` to exclude the last one.

5.  **Attribute Selector (Exact Match for Type):**

      * **Task:** Style all `input` elements with `type="date"` specifically: `border: 2px dashed #ff5722;`.
      * **Hint:** Use `input[type="date"] { border: 2px dashed #ff5722; }`.

6.  **Attribute Selector (Contains `*=`):**

      * **Task:** If any `div` on the page has a `class` attribute that contains the word "product" (e.g., `product-hero`, `product-description-section`), give it a `padding: 25px;` and `background-color: #ffffff;`. (This is redundant with existing styles but for demonstration).
      * **Hint:** Use `div[class*="product"] { padding: 25px; background-color: #ffffff; }`.

-----

#### **Task 8: Position Styles (Relative, Absolute, Fixed, Z-index)**

1.  **Product Image Badge:**

      * **Task:** Position the `span.new-badge` absolutely within its parent `.product-image-container`.
          * For `.product-image-container`: Set `position: relative;` (this is crucial for absolute children).
          * For `.new-badge`: Set `position: absolute; top: 10px; right: 10px;`.
          * Ensure its `z-index` is higher than other elements (e.g., `z-index: 10;`).
      * **Hint:** Absolute positioning positions an element relative to its closest *positioned* ancestor.

2.  **Floating Promo Banner:**

      * **Task:** Style the `div.promo-banner`.
          * Set `position: fixed;`.
          * Set `bottom: 0; left: 0; width: 100%;` to stick it to the bottom.
          * Give it `background-color: #fdd835;` (yellow), `color: #333;`, `padding: 10px 0;`, `text-align: center;`.
          * Ensure its `z-index` is high (e.g., `z-index: 999;`).
      * **Hint:** `position: fixed;` positions an element relative to the viewport, staying in place even when scrolling.

3.  **Submenu Positioning (Hidden by Default):**

      * **Task:** Hide the `.submenu` by default and position it absolutely relative to its parent `li.has-submenu`.
          * For `li.has-submenu`: Set `position: relative;` (required for absolute children).
          * For `.submenu`:
              * `display: none;` (to hide it).
              * `position: absolute; top: 100%; left: 0;` (to place it directly below its parent).
              * Give it a `background-color: #3f51b5;`, `min-width: 150px;`, `box-shadow: 0 2px 5px rgba(0,0,0,0.2);`, and `z-index: 900;`.
              * Remove default list styles: `list-style-type: none;`.
              * Add padding to its `li` and `a` elements for better click areas.
      * **Hint:** You'll use `:hover` on the parent `li.has-submenu` to make the `.submenu` appear.

4.  **Submenu Visibility on Hover:**

      * **Task:** When hovering over `li.has-submenu`, make its direct child `.submenu` visible.
      * **Hint:** Use `li.has-submenu:hover > .submenu { display: block; }`.

-----

### Part 9: Image and Link Styling

1.  **Product Image Styling:**

      * **Task:** Style `.product-main-image`:
          * `max-width: 100%;`
          * `height: auto;` (to maintain aspect ratio).
          * `display: block;` (to remove extra space below image).
          * `border-radius: 8px;`
          * `box-shadow: 0 4px 10px rgba(0,0,0,0.1);`
      * **Hint:** These are standard responsive image best practices.

2.  **Footer Links:**

      * **Task:** Style the `a` tag in the `footer`. Set `color: lightblue;` and `text-decoration: none;`. Add a `:hover` effect to `text-decoration: underline;`.
      * **Hint:** Target `footer a`.

3.  **Promo Banner Link:**

      * **Task:** Style the `.learn-more-link` in the `.promo-banner`: `display: inline-block; padding: 5px 10px; background-color: #333; color: white; text-decoration: none; border-radius: 3px; margin-left: 15px;`.
      * **Hint:** Make it look like a distinct button within the banner.

-----

### Part 10: Responsiveness (Media Queries)

1.  **Main Content Sections on Small Screens:**

      * **Task:** Use a media query for screens with a `max-width` of `768px`.
      * Inside this query, change `main`'s `flex-direction` to `column` to stack sections vertically.
      * For `.product-description-section`, change its `flex-direction` to `column` as well, so the description and sidebar also stack.
      * Adjust any margins or paddings that cause issues when stacking (e.g., remove `margin-right` on sections).
      * **Hint:** `flex-direction: column;` is key for vertical stacking in Flexbox.

2.  **Table Responsiveness:**

      * **Task:** For smaller screens (e.g., `max-width: 600px`), make the table (`.specs-table-container`) scrollable horizontally if content overflows.
      * **Hint:** Within your media query, apply `overflow-x: auto;` to `.specs-table-container`.

3.  **Navigation on Small Screens:**

      * **Task:** For smaller screens (`max-width: 768px`), make the main navigation (`.main-nav ul`) stack vertically.
      * **Hint:** Inside the media query, set `.main-nav ul { flex-direction: column; align-items: flex-start; }` (or similar). You might also want to hide the submenu by default and potentially show it with JavaScript or a "hamburger" menu if this were a full project. For this CSS assignment, just ensure the main menu items stack.

-----

**Submission:**

  * Save both `product-page.html` and `style.css` files.
  * Open `product-page.html` in your web browser.
  * **Crucially:** Use your browser's developer tools (Elements, Console, Network, etc.) extensively.
      * Inspect elements to see which CSS rules are applying and why.
      * Experiment with changing values directly in DevTools.
      * Use the device mode to test responsiveness.
      * Observe the box model in action for different elements.
