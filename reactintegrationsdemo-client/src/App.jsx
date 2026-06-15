import { useEffect, useState } from "react";
import "./App.css";

function App() {
  const [customers, setCustomers] = useState([]);

  useEffect(() => {
    fetch("https://localhost:7147/api/customers")
      .then((response) => response.json())
      .then((data) => setCustomers(data))
      .catch((error) => console.error("API error:", error));
  }, []);

  return (
    <main>
      <h1>React Integration Demo</h1>
      <p>Customer data fetched from a C#/.NET backend API.</p>

      {customers.map((customer) => (
        <div key={customer.id}>
          <strong>{customer.name}</strong>
          <p>{customer.email}</p>
        </div>
      ))}
    </main>
  );
}

export default App;