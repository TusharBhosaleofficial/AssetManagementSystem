function login() {
    const username = document.getElementById("username").value;
    const password = document.getElementById("password").value;

    fetch(`https://localhost:7136/api/auth/login?username=${username}&password=${password}`, {
        method: "POST"
    })
        .then(res => {
            if (!res.ok) throw new Error();
            return res.json();
        })
        .then(data => {
            localStorage.setItem("loggedIn", "true");
            localStorage.setItem("role", data.role);
            localStorage.setItem("employeeId", data.employeeId);

            if (data.role === "Admin") {
                window.location.href = "admin-dashboard.html";
            } else {
                window.location.href = "employee-dashboard.html";
            }
        })
        .catch(() => {
            document.getElementById("error").innerText = "Invalid credentials";
        });
}

function checkAuth() {
    if (localStorage.getItem("loggedIn") !== "true") {
        window.location.href = "login.html";
    }
}

function logout() {
    localStorage.clear();
    window.location.href = "login.html";
}
