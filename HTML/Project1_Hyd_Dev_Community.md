## Project: "Hyderabad Developers Community" All-in-One Profile & Info Page (HTML Only)

**Goal:** Create a single, comprehensive HTML page for the fictional "Hyderabad Developers Community." This page will serve multiple purposes: providing community information, outlining guidelines, and allowing user profile registration. Critically, it will showcase a vast array of fundamental HTML elements and form controls in a meaningful context. **Absolutely no CSS or JavaScript allowed** – focus solely on the native rendering and semantic structure of HTML elements.

**Why this project?**
 
  * **Contextual Learning:** Every element has a reason for being on the page, making its purpose clearer.
  * **Practical Application:** Simulates a real-world multi-purpose webpage.
  * **Semantic Reinforcement:** Encourages thinking about the *meaning* of content when choosing tags.

-----

### Project Requirements & Deliverables:

You will create one HTML file: `community-page.html`.

**General Instructions for Interns:**

1.  **File Naming:** Name your file `community-page.html`.
2.  **No Styling\!** Do not use any `<style>` tags, `style` attributes, or link to any `.css` files. The goal is to see the browser's default rendering.
3.  **No JavaScript\!** Do not use any `<script>` tags or inline JavaScript.
4.  **Labeling:** For **every form input**, use a `<label>` tag with a `for` attribute that matches the input's `id`. This is crucial for accessibility and good practice.
5.  **Organization:** Use `<h2>` and `<h3>` headings to organize your page into logical sections. Use `<hr>` (horizontal rule) to visually separate major sections.

-----

### Page Layout & Task Breakdown:

#### **Part 1: Page Header & Navigation**

**Task 1.1: Document Setup**

  * Create the basic HTML5 structure: `<!DOCTYPE html>`, `<html>`, `<head>`, `<body>`.
  * Set the page title within `<title>` to: "Hyderabad Developers Community - All-in-One Page".

**Task 1.2: Main Heading & Tagline**

  * Add a main heading (`<h1>`) at the top: "Hyderabad Developers Community".
  * Below it, add a short tagline (`<p>`) with emphasis: "Where Innovation Meets Collaboration in **Hyderabad\!**" (Use `<strong>` for "Hyderabad\!").

**Task 1.3: Internal Navigation Menu**

  * Create a navigation section (`<nav>`).
  * Inside `nav`, create an **unordered list (`<ul>`)** of links (`<li>` containing `<a>` tags) to jump to different sections on *this same page*. Use `href="#section-id"`.
      * "About Us" (link to `#about-section`)
      * "Community Guidelines" (link to `#guidelines-section`)
      * "Registration Form" (link to `#registration-form`)
      * "Contact Info" (link to `#contact-info`)
      * "Developer Resources" (link to `#resources-section`)

-----

#### **Part 2: About Us Section**

**Task 2.1: Section Heading & Introduction**

  * Start a new section (e.g., using `<div>` with `id="about-section"`).
  * Add an `<h2>` heading: "About Our Community".
  * Add an introductory paragraph (`<p>`) explaining what the community is about. Include a sentence with some `<em>` (italicized) text, like "We foster a *supportive and innovative* environment."

**Task 2.2: Our Mission (Blockquote & Cite)**

  * Add an `<h3>` heading: "Our Mission".
  * Include a `<blockquote>` for a mission statement or motto.
  * Below the blockquote, use a `<cite>` tag to attribute the quote or its source (e.g., `<cite>- Community Founders</cite>`).

**Task 2.3: Community Values (Ordered List)**

  * Add an `<h3>` heading: "Core Values".
  * Create an **ordered list (`<ol>`)** of at least 3 core values (e.g., "Collaboration", "Learning", "Innovation").
      * **Bonus:** Make one of the list items have a nested **unordered list (`<ul>`)** to show sub-points (e.g., under "Learning," list "Workshops," "Mentorship," "Hackathons").

**Task 2.4: Statistics (Simple Table)**

  * Add an `<h3>` heading: "Quick Facts".
  * Create a simple table (`<table>`) with `<thead>`, `<tbody>`, `<tr>`, `<th>`, `<td>` to display a few community statistics (e.g., "Members", "Events Held", "Years Active").
      * Example: | Statistic | Value |
        | --- | --- |
        | Members | 1500+ |
        | Events Held | 200+ |
        | Years Active | 5 |

**Task 2.5: Image Showcase**

  * Include an `<img>` tag of a relevant image (e.g., a group of developers, a tech logo). Remember to provide **meaningful `alt` text**.

-----

#### **Part 3: Community Guidelines**

  * Add a horizontal rule (`<hr>`) here.
  * Start a new section (`<div>` with `id="guidelines-section"`).
  * Add an `<h2>` heading: "Community Guidelines".
  * Add a paragraph (`<p>`) introducing the guidelines. Include some text that is `<u>` (underlined) to highlight a specific point, like "Please read these rules carefully before participating."

**Task 3.1: Rule Categories (Description List)**

  * Add an `<h3>` heading: "Key Principles".
  * Use a **description list (`<dl>`, `<dt>`, `<dd>`)** to define a few key principles (e.g., "Respectful Communication," "Constructive Feedback," "No Spam").
      * Example:
          * `<dt>Respectful Communication</dt>`
          * `<dd>Always engage in polite and professional discourse.</dd>`

**Task 3.2: Specific Rules (Unordered List with Text Formatting)**

  * Add an `<h3>` heading: "Specific Rules".
  * Create an **unordered list (`<ul>`)** for detailed rules.
  * Inside one of the `<li>` items, include:
      * Some `<strong>` text.
      * A line break (`<br>`).
      * A code snippet using `<code>` (e.g., `<code>console.log("Hello World");</code>`).
      * A strikethrough text (`<del>`).
      * A paragraph with `<sup>` (superscript) and `<sub>` (subscript) text (e.g., "Our community's 1\<sup\>st\</sup\> rule is about H\<sub\>2\</sub\>O and staying hydrated.").
  * **Bonus:** Add an `abbr` tag for an abbreviation (e.g., `<abbr title="Frequently Asked Questions">FAQ</abbr>`).

-----

#### **Part 4: Profile Registration Form**

  * Add a horizontal rule (`<hr>`) here.
  * Start a new section (`<form>` with `id="registration-form"`).
  * Add an `<h2>` heading: "New Member Registration".
  * Add a short introductory paragraph (`<p>`) for the form.

**Task 4.1: Personal Information (Text, Email, Password, Date, Number)**

  * Add an `<h3>` heading: "Your Personal Details".
  * For each of below input give id, type, placeholder, name and required or not.
  * **Full Name:** `<label>` and `<input>`.
  * **Email:**  `<label>` and `<input>`.
  * **Password:**  `<label>` and `<input>` with minlength of 8.
  * **Phone Number:** `<label>` and `<input type="tel" id="phone" placeholder="e.g., +91 9876543210">`.
  * **Date of Birth:** `<label>` and `<input type="date" id="dob">`.

**Task 4.2: Gender (Radio Buttons)**

  * Add an `<h3>` heading: "Gender".
  * Create **radio buttons (`<input type="radio">`)** for "Male", "Female", "Prefer not to say".
      * All radios should have the same `name` attribute (e.g., `name="gender"`).
      * Each needs a unique `id` and corresponding `<label>`.
      * Pre-select "Prefer not to say" using `checked`.

**Task 4.3: Professional & Technical Details (Dropdown, Checkboxes, Range, Textarea)**

  * Add an `<h3>` heading: "Your Professional Background".
  * **Primary Role (Dropdown):** `<label>` and `<select id="role">`.
      * First option: `<option value="" disabled selected>Select your role</option>`.
      * At least 5 real roles (e.g., "Frontend Developer", "Backend Developer", "DevOps Engineer").
  * **Years of Experience (Range Slider):** `<label>Years of Experience: <input type="range" id="experience" min="0" max="25" value="5"></label>`.
  * **Skills (Checkboxes):** `<label>` and multiple checkboxes (`<input type="checkbox">`) for "HTML", "SQL", "C\#", "JavaScript", "Python". Give them a common `name` attribute like `name="skills[]"`. Pre-select "HTML" and "SQL".
  * **Preferred Learning Style (Multi-select Dropdown):** `<label>` and `<select id="learningStyle" multiple size="3">`.
      * Options: "Hands-on Projects", "Video Tutorials", "Reading Documentation", "Live Workshops".
  * **Bio (Textarea):** `<label>Tell us about yourself and your interests:</label><textarea id="bio" rows="6" cols="70" placeholder="e.g., I'm passionate about building scalable web applications..."></textarea>`.

**Task 4.4: Community Preferences (File Input, URL, Color, Time, Datalist)**

  * Add an `<h3>` heading: "Community Preferences".
  * **Profile Picture:** `<label>` and `<input type="file" id="profilePic" accept="image/*">`.
  * **Personal Website/Portfolio URL:** `<label>` and `<input type="url" id="website" placeholder="https://yourwebsite.com">`.
  * **Favorite Color (for profile badge):** `<label>` and `<input type="color" id="favColor" value="#0056b3">`.
  * **Preferred Event Time:** `<label>` and `<input type="time" id="eventTime" value="19:00">`.
  * **How did you hear about us? (Datalist):** `<label>` and `<input type="text" list="referralSource" id="referral">`.
      * `<datalist id="referralSource">` with `<option>`s like "Friend", "Social Media", "Search Engine", "Community Event".

**Task 4.5: Agreements & Submission**

  * **Terms & Conditions:** `<label>` and `<input type="checkbox" id="terms" required> I agree to the <a href="dummy-terms.html" target="_blank">Community Terms & Conditions</a>.</label>`. (The `dummy-terms.html` file does not need to exist, but the link should be there).
  * **Submit Buttons:**
      * `<button type="submit">Register My Profile</button>`
      * `<input type="submit" value="Sign Up (Input Type)">` (to show the difference).
  * **Reset Buttons:**
      * `<button type="reset">Clear Form</button>`
      * `<input type="reset" value="Reset All (Input Type)">` (to show the difference).

-----

#### **Part 5: Contact Information & Footer**

  * Add a horizontal rule (`<hr>`) here.
  * Start a new section (`<div>` with `id="contact-info"`).
  * Add an `<h2>` heading: "Contact & Location".
  * **Address:** Use the `<address>` tag for the community's fictional address (e.g., "Hyderabad Developers Hub, Hitech City, Hyderabad, Telangana, India - 500081").
  * **Phone & Email Links:**
      * `<p>Phone: <a href="tel:+918008008008">+91 8008008008</a></p>`
      * `<p>Email: <a href="mailto:info@hyddevs.com">info@hyddevs.com</a></p>`
  * **External Map Link:** `<p><a href="https://maps.app.goo.gl/example" target="_blank">View on Google Maps (Simulated)</a></p>`. (Use a dummy Google Maps link).

-----

#### **Part 6: Developer Resources (Advanced/Semantic Elements)**

  * Add a horizontal rule (`<hr>`) here.
  * Start a new section (`<div>` with `id="resources-section"`).
  * Add an `<h2>` heading: "Developer Resources".
  * **Article (Simulated):** Use an `<article>` tag to simulate a blog post snippet.
      * Inside the article, add an `<h3>` heading for the article title.
      * Include a paragraph (`<p>`) with a simulated `<blockquote>` (a short quote).
      * Add a simple paragraph containing `<code>` for an inline code example (e.g., `console.log("Hello Hyderabad!");`).
  * **Aside (Simulated Sidebar Tip):** Use an `<aside>` tag to represent a sidebar or complementary content.
      * Inside, add an `<h3>` heading "Quick Tip:".
      * Add a paragraph with a **`<span>`** to highlight a word or phrase within the sentence.
  * **Figure and Figcaption:** Show an image related to coding with a caption.
      * `<figure>`
      * `<img src="dummy-code-snippet.png" alt="Code snippet example">`
      * `<figcaption>Example of a basic HTML structure.</figcaption>`

-----
