export async function getCustomers() {
  const response = await fetch("https://localhost:7147/api/customers");

  if (!response.ok) {
    throw new Error("Could not fetch customers");
  }

  return await response.json();
}