import { useEffect, useState } from "react";
import { getCustomers } from "./services/customerService";
import "./App.css";

function App() {
  const [customers, setCustomers] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState("");

  useEffect(() => {
    getCustomers()
      .then((data) => {
        setCustomers(data);
        setLoading(false);
      })
      .catch(() => {
        setError("Could not connect to the backend API.");
        setLoading(false);
      });
  }, []);

  if (loading) {
    return <p>Loading customers...</p>;
  }

  if (error) {
    return <p>{error}</p>;
  }

  return (
    <main>
      <h1>React Integration Demo</h1>
      <p>Customer data fetched from a C#/.NET backend API.</p>

      <h2>Total customers: {customers.length}</h2>

      <section>
        {customers.map((customer) => (
          <article key={customer.id}>
            <h3>{customer.name}</h3>
            <p>{customer.email}</p>
          </article>
        ))}
      </section>
    </main>
  );
}

export default App;