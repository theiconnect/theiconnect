-----

## HTML Controls Quick Reference Guide

This guide provides a concise overview of common HTML elements, focusing on their purpose, key attributes, default behaviors, and custom attributes.

-----

### **1. Basic Document Structure & Text**

| Control Name | Purpose | Most Used Attributes | Default Attributes/Values (if applicable) | Custom Attributes (with Purpose) |
| :----------- | :------ | :------------------- | :---------------------------------------- | :------------------------------- |
| **`<html>`** | The root element of an HTML page. | `lang` | `lang="en"` (often implied or set by browser) | `lang` - Specifies the primary language of the document (e.g., `es` for Spanish). Essential for accessibility and search engines. |
| **`<head>`** | Container for metadata (data about the HTML document) that is not displayed on the web page. | - | - | - |
| **`<title>`** | Defines the title of the document, shown in the browser's title bar or tab. | - | No default value, must be provided. | - |
| **`<body>`** | Contains all the visible content of a web page. | - | - | - |
| **`<h1>` to `<h6>`** | Define headings of different levels. `<h1>` is the most important, `<h6>` is the least. | - | Default font size and weight decrease from `h1` to `h6`. | - |
| **`<p>`** | Defines a paragraph of text. | - | Block-level element; creates a new line before and after. | - |
| **`<br>`** | Inserts a single line break. | - | No closing tag. | - |
| **`<hr>`** | Defines a thematic break in content (e.g., a horizontal line). | - | Displays as a horizontal line. | - |
| **`<strong>`** | Defines important text (semantically strong emphasis). | - | Renders as **bold** by default. | - |
| **`<em>`** | Defines emphasized text (semantically emphasizes content). | - | Renders as *italic* by default. | - |
| **`<u>`** | Defines text that should be stylistically different from normal text, such as a misspelled word. (Often discouraged for simple underlining; use CSS instead). | - | Renders as \<u\>underlined\</u\> by default. | - |
| **`<del>`** | Defines text that has been deleted from a document. | - | Renders as \<del\>strikethrough\</del\> by default. | - |
| **`<s>`** | Defines text that is no longer accurate or relevant (strikethrough). | - | Renders as \<s\>strikethrough\</s\> by default. | - |
| **`<sup>`** | Defines superscripted text (e.g., for exponents). | - | Renders text slightly above the normal line. | - |
| **`<sub>`** | Defines subscripted text (e.g., for chemical formulas). | - | Renders text slightly below the normal line. | - |
| **`<code>`** | Defines a piece of computer code. | - | Renders in a monospace font by default. | - |
| **`<pre>`** | Defines preformatted text. Text inside this tag is displayed in a fixed-width font, and it preserves both spaces and line breaks. | - | Renders in a monospace font, preserves whitespace. | `wrap` - A non-standard but widely supported attribute that specifies whether the text in a `<pre>` element should wrap. |
| **`<blockquote>`** | Defines a section that is quoted from another source. | `cite` | Indented by default. | `cite` - Specifies the URL of the source of the quotation. |
| **`<cite>`** | Defines the title of a creative work (e.g., a book, song, or movie). | - | Renders as *italic* by default. | - |
| **`<dfn>`** | Defines the term being defined within the surrounding content. | - | Renders as *italic* by default. | - |
| **`<abbr>`** | Defines an abbreviation or an acronym. | `title` | - | `title` - Provides the full description of the abbreviation, which appears on hover. |
| **`<div>`** | A generic block-level container for flow content. Used to group elements for styling with CSS or manipulating with JavaScript. | `id`, `class` | Block-level; takes full width. | `id` - Unique identifier for the element. `class` - Class name for grouping elements for styling/scripting. |
| **`<span>`** | A generic inline container for phrasing content. Used to group inline-elements for styling with CSS or manipulating with JavaScript. | `id`, `class` | Inline-level; takes only as much width as its content. | `id` - Unique identifier for the element. `class` - Class name for grouping elements for styling/scripting. |

-----

### **2. Links & Images**

| Control Name | Purpose | Most Used Attributes | Default Attributes/Values (if applicable) | Custom Attributes (with Purpose) |
| :----------- | :------ | :------------------- | :---------------------------------------- | :------------------------------- |
| **`<a>`** | Defines a hyperlink, used to link from one page to another. | `href` | Underlined and blue (visited links purple). | `target` - Specifies where to open the linked document (`_blank` for new tab, `_self` for same tab). `rel` - Specifies the relationship between the current document and the linked document (e.g., `nofollow`, `noopener`). `download` - Prompts the user to download the URL instead of navigating to it. |
| **`<img>`** | Embeds an image into the document. | `src`, `alt` | - | `width`, `height` - Specify the image's dimensions in pixels (though often handled by CSS). `loading` - Suggests how the browser should load the image (`lazy` for off-screen images). `title` - Provides a tooltip on hover. |

-----

### **3. Lists**

| Control Name | Purpose | Most Used Attributes | Default Attributes/Values (if applicable) | Custom Attributes (with Purpose) |
| :----------- | :------ | :------------------- | :---------------------------------------- | :------------------------------- |
| **`<ul>`** | Defines an unordered (bulleted) list. | - | Uses disc bullets by default. | `type` (Deprecated, use CSS) - Specifies bullet style (e.g., `circle`, `square`). |
| **`<ol>`** | Defines an ordered (numbered) list. | - | Uses numbers by default. | `type` - Specifies the type of marker (e.g., `1` for numbers, `a` for lowercase letters, `I` for uppercase Roman numerals). `start` - Specifies the start value of the list. `reversed` - Specifies that the list order should be descending. |
| **`<li>`** | Defines a list item within `<ul>` or `<ol>`. | - | - | `value` - For ordered lists, sets the value of the current list item, and subsequent items increment from that value. |
| **`<dl>`** | Defines a description list. | - | - | - |
| **`<dt>`** | Defines a term/name in a description list. | - | - | - |
| **`<dd>`** | Defines a description of the term/name in a description list. | - | Indented by default. | - |

-----

### **4. Tables**

| Control Name | Purpose | Most Used Attributes | Default Attributes/Values (if applicable) | Custom Attributes (with Purpose) |
| :----------- | :------ | :------------------- | :---------------------------------------- | :------------------------------- |
| **`<table>`** | Defines an HTML table. | - | No default borders or styling. | `border` (Deprecated, use CSS) - Specifies the width of the table border. `cellpadding`, `cellspacing` (Deprecated, use CSS) - Control spacing within and between cells. |
| **`<caption>`** | Defines a table caption (title), which is displayed at the top of the table. | - | - | - |
| **`<thead>`** | Groups the header content in a table. | - | - | - |
| **`<tbody>`** | Groups the body content in a table. | - | - | - |
| **`<tr>`** | Defines a row in a table. | - | - | - |
| **`<th>`** | Defines a header cell in a table. | `scope` | Renders as **bold** and centered by default. | `scope` - Specifies whether the header applies to a row, column, rowgroup, or colgroup. `colspan` - Specifies the number of columns a header cell should span. `rowspan` - Specifies the number of rows a header cell should span. |
| **`<td>`** | Defines a standard data cell in a table. | - | - | `colspan` - Specifies the number of columns a data cell should span. `rowspan` - Specifies the number of rows a data cell should span. |

-----

### **5. Forms & Input Controls**

| Control Name | Purpose | Most Used Attributes | Default Attributes/Values (if applicable) | Custom Attributes (with Purpose) |
| :----------- | :------ | :------------------- | :---------------------------------------- | :------------------------------- |
| **`<form>`** | Defines an HTML form for user input. | `action`, `method` | `method="get"` (if not specified) | `action` - URL where form data is sent upon submission. `method` - HTTP method for sending data (`get`, `post`). `enctype` - Specifies how form data should be encoded (for file uploads). `target` - Where to display the response after submitting the form. `autocomplete` - On/Off for browser's autocomplete. |
| **`<label>`** | Defines a label for an `<input>` element. | `for` | - | `for` - Explicitly associates the label with an input via the input's `id` (crucial for accessibility). |
| **`<input type="text">`** | Single-line text input field. | `name`, `id` | `type="text"`, `required=false` | `placeholder` - Displays hint text in the input field. `value` - Pre-loads the input with a specific text. `required` - Makes the field mandatory. `maxlength` - Maximum number of characters allowed. `minlength` - Minimum number of characters required. `readonly` - Makes the field non-editable. `disabled` - Disables the input field. `size` - Visible width of the input in characters. `autocomplete` - Suggests values for the field. |
| **`<input type="password">`** | Password input field (masks characters). | `name`, `id` | - | `minlength`, `maxlength`, `placeholder`, `required`, `readonly`, `disabled` (same as text input). |
| **`<input type="email">`** | Input field for email addresses. Includes basic client-side email format validation. | `name`, `id` | - | `placeholder`, `required`, `readonly`, `disabled`, `multiple` (allows multiple email addresses). `pattern` - A regular expression for validation. |
| **`<input type="number">`** | Input field for numbers. Includes arrow buttons to increment/decrement. | `name`, `id` | - | `min` - Minimum allowed value. `max` - Maximum allowed value. `step` - Interval for incrementing/decrementing. `placeholder`, `required`, `readonly`, `disabled`. |
| **`<input type="tel">`** | Input field for telephone numbers. Optimizes mobile keyboard for numbers. | `name`, `id` | - | `placeholder`, `required`, `readonly`, `disabled`, `pattern`. |
| **`<input type="url">`** | Input field for URLs. Includes basic client-side URL format validation. | `name`, `id` | - | `placeholder`, `required`, `readonly`, `disabled`, `pattern`. |
| **`<input type="date">`** | Date input field (opens a date picker). | `name`, `id` | - | `min`, `max` - Restrict selectable date range. `value` - Pre-fills the date. `required`, `readonly`, `disabled`. |
| **`<input type="time">`** | Time input field (opens a time picker). | `name`, `id` | - | `min`, `max` - Restrict selectable time range. `value` - Pre-fills the time. `required`, `readonly`, `disabled`. |
| **`<input type="color">`** | Color picker input field. | `name`, `id` | `value="#000000"` (black) | `value` - Pre-fills the color. `required`, `disabled`. |
| **`<input type="range">`** | Slider control for numeric input within a specified range. | `name`, `id`, `min`, `max` | `min=0`, `max=100`, `value=50` | `step` - Defines the legal number intervals. `value` - Sets the initial position of the slider. `disabled`. |
| **`<input type="checkbox">`** | Checkbox for selecting one or more options. | `name`, `id` | `checked=false` | `value` - The value sent when the checkbox is checked. `checked` - Makes the checkbox pre-selected. `required`, `disabled`. |
| **`<input type="radio">`** | Radio button for selecting *one* option from a group. | `name`, `id` | `checked=false` | `value` - The value sent when the radio button is selected. `checked` - Makes the radio button pre-selected. `required`, `disabled`. **Note:** Radio buttons in the same group **must** have the same `name` attribute. |
| **`<textarea>`** | Multi-line text input area. | `name`, `id`, `rows`, `cols` | `rows=2`, `cols=20` (browser defaults vary) | `placeholder`, `required`, `readonly`, `disabled`, `minlength`, `maxlength`, `wrap` (how text wraps). |
| **`<select>`** | Dropdown list. | `name`, `id` | - | `size` - Number of visible options without scrolling. `multiple` - Allows selection of multiple options (use Ctrl/Cmd-click). `required`, `disabled`. |
| **`<option>`** | Defines an option within a `<select>` or `<datalist>`. | `value` | - | `selected` - Makes this option pre-selected. `disabled` - Disables this option. `label` - Short text for the option (if different from content). |
| **`<input type="file">`** | File upload input field. | `name`, `id` | - | `accept` - Specifies acceptable file types (e.g., `image/*`, `.pdf`). `multiple` - Allows selection of multiple files. `required`, `disabled`. |
| **`<input type="hidden">`** | An input field that is not visible to the user but its value is submitted with the form. | `name`, `id`, `value` | - | `value` - The value to be submitted. |
| **`<input type="submit">`** | Button to submit form data. | `value` | `value="Submit Query"` (browser default) | `value` - Text displayed on the button. `disabled`. |
| **`<input type="reset">`** | Button to reset form fields to their initial values. | `value` | `value="Reset"` (browser default) | `value` - Text displayed on the button. `disabled`. |
| **`<input type="button">`** | Generic clickable button (requires JavaScript to do anything). | `value` | `value="Button"` (browser default) | `value` - Text displayed on the button. `disabled`. |
| **`<button>`** | A more versatile button element (can contain text, images). | `type` | `type="submit"` (if not specified) | `type` - Specifies button behavior (`submit`, `reset`, `button`). `disabled`. |
| **`<datalist>`** | Provides a list of pre-defined options for an `<input>` element. | `id` | - | `id` - Must match the `list` attribute of the associated `<input>`. |

-----

### **6. Semantic & Media Elements**

| Control Name | Purpose | Most Used Attributes | Default Attributes/Values (if applicable) | Custom Attributes (with Purpose) |
| :----------- | :------ | :------------------- | :---------------------------------------- | :------------------------------- |
| **`<header>`** | Represents introductory content, typically containing a group of navigational aids or introductory headings. | - | Block-level. | - |
| **`<nav>`** | Defines a section of navigation links. | - | Block-level. | - |
| **`<main>`** | Represents the dominant content of the `<body>`. There should only be one `<main>` element per document. | - | Block-level. | - |
| **`<section>`** | Represents a standalone section of content that doesn't have a more specific semantic element to represent it. | - | Block-level. | - |
| **`<article>`** | Represents self-contained content, like a blog post, news story, or comment. | - | Block-level. | - |
| **`<aside>`** | Represents a portion of a document whose content is only indirectly related to the document's main content (e.g., a sidebar, pull quote). | - | Block-level. | - |
| **`<footer>`** | Defines a footer for a document or section, typically containing authorship information, copyright data, or related links. | - | Block-level. | - |
| **`<audio>`** | Embeds sound content. | `controls` | - | `src` - URL of the audio file. `controls` - Displays default audio controls (play/pause, volume). `autoplay` - Starts playing automatically. `loop` - Repeats playback. `muted` - Mutes audio by default. `preload` - Hints how the browser should load the audio. |
| **`<video>`** | Embeds video content. | `controls` | - | `src` - URL of the video file. `controls` - Displays default video controls. `autoplay`, `loop`, `muted`, `preload` (similar to audio). `width`, `height` - Dimensions. `poster` - Image to display before video plays. |
| **`<source>`** | Specifies multiple media resources for `<audio>` or `<video>` elements. | `src`, `type` | - | `media` - Media query to specify when a resource should be used. |
| **`<figure>`** | Used to group self-contained content, often with a caption (`<figcaption>`). | - | Block-level. | - |
| **`<figcaption>`** | Defines a caption for the `<figure>` element. | - | - | - |
| **`<small>`** | Represents side comments and small print, like copyright and legal text. | - | Renders text in a smaller font size. | - |

-----
