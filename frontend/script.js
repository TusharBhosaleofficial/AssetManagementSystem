// ================= BASE API =================
const API_BASE = "https://localhost:7136/api";

// ================= ASSETS (ADMIN) =================

// Load all assets
function loadAssets() {
    fetch(`${API_BASE}/Assets`)
        .then(res => res.json())
        .then(data => {
            const list = document.getElementById("assetList");
            list.innerHTML = "";

            if (data.length === 0) {
                list.innerHTML = "<li>No assets available</li>";
                return;
            }

            data.forEach(a => {
                const li = document.createElement("li");

                li.innerHTML = `
                    <span>${a.assetName}</span>
                    <span class="status ${a.status === "Assigned" ? "assigned" : "unassigned"}">
                        ${a.status}
                    </span>
                `;

                list.appendChild(li);
            });
        })
        .catch(() => {
            alert("Failed to load assets");
        });
}

// Add new asset
function addAsset() {
    const asset = {
        assetName: document.getElementById("name").value,
        assetType: document.getElementById("type").value,
        serialNumber: document.getElementById("serial").value,
        purchaseDate: document.getElementById("date").value,
        price: parseFloat(document.getElementById("price").value)
    };

    fetch(`${API_BASE}/Assets`, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(asset)
    })
        .then(() => {
            alert("Asset added successfully");
            loadAssets();
        });
}

// ================= EMPLOYEES (ADMIN) =================

// Load all employees
function loadEmployees() {
    fetch(`${API_BASE}/Employees`)
        .then(res => res.json())
        .then(data => {
            const table = document.getElementById("employeeTable");
            table.innerHTML = "";

            data.forEach(e => {
                const row = document.createElement("tr");

                row.innerHTML = `
                    <td>${e.employeeId}</td>
                    <td>${e.name}</td>
                    <td>${e.email}</td>
                    <td>${e.department}</td>
                `;

                table.appendChild(row);
            });
        });
}

function addEmployee() {
    const name = document.getElementById("name").value;
    const email = document.getElementById("email").value;
    const department = document.getElementById("department").value;

    fetch(`${API_BASE}/Employees`, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({ name, email, department })
    })
        .then(() => {
            loadEmployees();
            document.getElementById("name").value = "";
            document.getElementById("email").value = "";
            document.getElementById("department").value = "";
        });
}


// ================= EMPLOYEE FEATURES =================

// Load assets assigned to logged-in employee
function loadMyAssets() {
    const employeeId = localStorage.getItem("employeeId");

    fetch(`${API_BASE}/Assets/employee/${employeeId}`)
        .then(res => res.json())
        .then(data => {
            const list = document.getElementById("assetList");
            list.innerHTML = "";

            if (data.length === 0) {
                list.innerHTML = "<li>No assets assigned</li>";
                return;
            }

            data.forEach(a => {
                const li = document.createElement("li");
                li.innerText = `${a.assetName} - ${a.status}`;
                list.appendChild(li);
            });
        });
}

// Request asset (employee)
function requestAsset() {
    const employeeId = localStorage.getItem("employeeId");
    const assetType = document.getElementById("assetType").value;

    fetch(`${API_BASE}/AssetRequests`, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({
            employeeId: employeeId,
            assetType: assetType
        })
    })
        .then(() => {
            document.getElementById("msg").innerText = "Asset request submitted";
        });
}

function loadRequests() {
    fetch("https://localhost:7136/api/AssetRequests")
        .then(res => res.json())
        .then(data => {
            const table = document.getElementById("requestTable");
            table.innerHTML = "";

            data.forEach(r => {
                const row = document.createElement("tr");

                row.innerHTML = `
          <td>${r.requestId}</td>
          <td>${r.employeeId}</td>
          <td>${r.assetType}</td>
          <td>${r.status}</td>
          <td>
            <button onclick="approveRequest(${r.requestId})">Approve</button>
            <button onclick="rejectRequest(${r.requestId})">Reject</button>
          </td>
        `;

                table.appendChild(row);
            });
        });
}

function approveRequest(requestId) {
    const assetId = prompt("Enter Asset ID to assign");

    fetch(`https://localhost:7136/api/AssetRequests/approve/${requestId}?assetId=${assetId}`, {
        method: "POST"
    })
        .then(() => {
            alert("Request approved");
            loadRequests();
        });
}

function rejectRequest(requestId) {
    fetch(`https://localhost:7136/api/AssetRequests/reject/${requestId}`, {
        method: "POST"
    })
        .then(() => {
            alert("Request rejected");
            loadRequests();
        });
}

