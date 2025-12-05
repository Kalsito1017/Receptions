document.querySelector('form[action*="formspree"]').addEventListener('submit', function (e) {
    e.preventDefault();
    const form = this;
    fetch(form.action, {
        method: 'POST',
        body: new FormData(form),
        headers: { 'Accept': 'application/json' }
    }).then(response => {
        if (response.ok) {
            document.getElementById('form-message').style.display = 'block';
            form.reset();
        }
    });
});
