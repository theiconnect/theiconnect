// Client behaviors for Employee Edit page (Razor Pages / static page compatible)
// - Auto-generate EmployeeId and EmployeeCode (client fallback, server should be authoritative)
// - Populate selects if empty
// - Restrict name inputs to letters + spaces (typing & paste & IME-friendly)
// - Restrict mobile to digits only (max 10)
// - jQuery UI datepicker (dd/mm/yyyy) with year navigation, show on hover/focus
// - Light client-side validation and Cancel navigation
// - Populate form from query string or localStorage.employeeForEdit when opened from EmployeeList edit button
// - If no source data found, populate form with a sample data object (for testing/demo)
(function ($) {
    'use strict';

    var EMP_ID_KEY = 'ems_emp_id_counter';
    var EMP_CODE_KEY = 'ems_emp_code_counter';
    var LOCAL_STORAGE_KEY = 'employeeForEdit';

    function nextCounter(key) {
        try {
            var cur = parseInt(localStorage.getItem(key) || '0', 10) || 0;
            cur = cur + 1;
            localStorage.setItem(key, cur.toString());
            return cur;
        } catch (e) {
            return Date.now() % 100000; // fallback
        }
    }

    function generateEmployeeId() {
        // e.g. numeric id fallback
        var n = nextCounter(EMP_ID_KEY);
        return String(n);
    }

    function generateEmployeeCode() {
        // HR001 style using a counter (client fallback)
        var n = nextCounter(EMP_CODE_KEY);
        return 'HR' + ('000' + (n % 1000)).slice(-3);
    }

    function initPopulateSelects() {
        var genders = ['Male', 'Female', 'Others'];
        var bloods = ['A positive','A negative','B positive','B negative','O positive','O negative','AB positive','AB negative'];
        var quals = ['BTech', 'MTech'];
        var desigs = ['JuniorDeveloper', 'SeniorDeveloper', 'HR Manager'];

        function ensure($sel, items) {
            if (!$sel.length) return;
            // if only placeholder or empty, populate
            if ($sel.children('option').length <= 1) {
                items.forEach(function(it) {
                    $sel.append($('<option>').val(it).text(it));
                });
            }
        }

        ensure($('#Gender'), genders);
        ensure($('#BloodGroup'), bloods);
        ensure($('#Qualification'), quals);
        ensure($('#DesignationType'), desigs);
    }

    function initIdsAndCodes() {
        var $id = $('#EmployeeId');
        var $code = $('#EmployeeCode');
        if ($id.length && !$id.val().trim()) $id.val(generateEmployeeId());
        if ($code.length && !$code.val().trim()) $code.val(generateEmployeeCode());
    }

    function initDatepickers() {
        if (!$.datepicker) return;
        $('.datepicker').each(function () {
            var $el = $(this);
            $el.datepicker({
                dateFormat: 'dd/mm/yy',
                changeMonth: true,
                changeYear: true,
                yearRange: '-100:+10',
                showButtonPanel: true
            });
            // show on hover and on focus
            $el.on('mouseenter focus', function () {
                try { $(this).datepicker('show'); } catch (e) { /* ignore */ }
            });
        });
    }

    // Allow only letters and spaces, robust for typing and paste (keeps IME behavior)
    function restrictNames(selector) {
        $(selector).on('input', function () {
            var val = this.value;
            var filtered = val.replace(/[^A-Za-z\s\u00C0-\u017F]/g, ''); // allow Latin accents
            if (filtered !== val) {
                this.value = filtered;
            }
        }).on('keypress', function (e) {
            var code = e.which || e.keyCode;
            if (e.ctrlKey || e.metaKey || e.altKey) return;
            // allow control keys
            if (code === 8 || code === 13 || code === 9 || code === 27) return;
            var ch = String.fromCharCode(code);
            if (!/^[A-Za-z\s\u00C0-\u017F]$/.test(ch)) {
                e.preventDefault();
            }
        }).on('paste', function (e) {
            var clipboard = '';
            var oe = e.originalEvent || {};
            if (oe.clipboardData && typeof oe.clipboardData.getData === 'function') {
                clipboard = oe.clipboardData.getData('text') || '';
            } else if (window.clipboardData && typeof window.clipboardData.getData === 'function') {
                clipboard = window.clipboardData.getData('Text') || '';
            }
            var filtered = clipboard.replace(/[^A-Za-z\s\u00C0-\u017F]/g, '');
            if (filtered !== clipboard) {
                e.preventDefault();
                var el = this;
                var start = el.selectionStart || 0;
                var end = el.selectionEnd || 0;
                var val = el.value;
                el.value = val.slice(0, start) + filtered + val.slice(end);
                try { el.setSelectionRange(start + filtered.length, start + filtered.length); } catch (err) {}
                $(el).trigger('input');
            }
        });
    }

    function restrictMobile() {
        var $m = $('#MobileNumber');
        if (!$m.length) return;
        $m.attr('inputmode', 'numeric');
        $m.on('input', function () {
            var v = this.value.replace(/\D/g, '').slice(0, 10);
            if (this.value !== v) this.value = v;
        }).on('paste', function (e) {
            var clipboard = '';
            var oe = e.originalEvent || {};
            if (oe.clipboardData && typeof oe.clipboardData.getData === 'function') {
                clipboard = oe.clipboardData.getData('text') || '';
            } else if (window.clipboardData && typeof window.clipboardData.getData === 'function') {
                clipboard = window.clipboardData.getData('Text') || '';
            }
            var filtered = clipboard.replace(/\D/g, '').slice(0, 10);
            if (filtered !== clipboard) {
                e.preventDefault();
                var el = this;
                var start = el.selectionStart || 0;
                var end = el.selectionEnd || 0;
                var val = el.value;
                el.value = val.slice(0, start) + filtered + val.slice(end);
                try { el.setSelectionRange(start + filtered.length, start + filtered.length); } catch (err) {}
                $(el).trigger('input');
            }
        });
    }

    function isValidDateString(txt) {
        if (!txt) return true;
        var re = /^(0[1-9]|[12]\d|3[01])\/(0[1-9]|1[0-2])\/\d{4}$/;
        if (!re.test(txt)) return false;
        var parts = txt.split('/');
        var d = parseInt(parts[0], 10), m = parseInt(parts[1], 10) - 1, y = parseInt(parts[2], 10);
        var dt = new Date(y, m, d);
        return dt && dt.getFullYear() === y && dt.getMonth() === m && dt.getDate() === d;
    }

    function initFormValidation() {
        var $form = $('#employeeForm');
        if (!$form.length) return;

        $form.on('submit', function (e) {
            var ok = true;
            $('.field-error').text('');

            var first = ($('#FirstName').val() || '').trim();
            var last = ($('#LastName').val() || '').trim();
            var email = ($('#Email').val() || '').trim();
            var mobile = ($('#MobileNumber').val() || '').trim();
            var dob = ($('#DateOfBirth').val() || '').trim();
            var doj = ($('#DateOfJoining').val() || '').trim();

            if (!first) { $('#FirstNameError').text('First name is required.'); ok = false; }
            else if (!/^[A-Za-z\s\u00C0-\u017F]+$/.test(first)) { $('#FirstNameError').text('Only letters and spaces allowed.'); ok = false; }

            if (!last) { $('#LastNameError').text('Last name is required.'); ok = false; }
            else if (!/^[A-Za-z\s\u00C0-\u017F]+$/.test(last)) { $('#LastNameError').text('Only letters and spaces allowed.'); ok = false; }

            if (!email) { $('#EmailError').text('Email is required.'); ok = false; }
            else {
                var emailRe = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
                if (!emailRe.test(email)) { $('#EmailError').text('Enter a valid email.'); ok = false; }
            }

            if (!/^\d{10}$/.test(mobile)) { $('#MobileError').text('Enter 10 digit mobile number.'); ok = false; }

            if (dob && !isValidDateString(dob)) { $('#DobError').text('DOB must be dd/mm/yyyy.'); ok = false; }
            if (doj && !isValidDateString(doj)) { $('#DojError').text('DOJ must be dd/mm/yyyy.'); ok = false; }

            if (!ok) {
                e.preventDefault();
                var $firstErr = $('.field-error').filter(function () { return $(this).text().trim() !== ''; }).first();
                if ($firstErr.length) {
                    var $input = $firstErr.siblings('input,select,textarea').first();
                    if (!$input.length) $input = $firstErr.prevAll('input,select,textarea').first();
                    if ($input.length) $input.focus();
                }
            }
        });
    }

    function initCancel() {
        $(document).on('click', '#btnCancel, .btn-cancel', function (e) {
            e.preventDefault();
            window.location.href = '/Employee/list';
        });
    }

    // Parse query string into object
    function parseQuery() {
        var q = window.location.search.substring(1);
        if (!q) return {};
        return q.split('&').reduce(function (acc, pair) {
            var parts = pair.split('=');
            var k = decodeURIComponent(parts[0] || '');
            var v = decodeURIComponent(parts[1] || '');
            if (k) acc[k] = v;
            return acc;
        }, {});
    }

    // Read localStorage fallback
    function getLocalEmployee() {
        try {
            var j = localStorage.getItem(LOCAL_STORAGE_KEY);
            if (!j) return null;
            return JSON.parse(j);
        } catch (e) { return null; }
    }

    // Sample data used when no query/localStorage provided
    function getSampleData() {
        return {
            Id: "1001",
            EmployeeCode: "HR001",
            FirstName: "Asha",
            LastName: "Kumar",
        }
    }

    function toclickok() {
        location.href = "/Employee/EmployeeList";
    }