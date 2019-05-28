import React, { useState, useEffect } from "react";

import "./styles.css";

export default function SearchInput(props) {
  const [search, setSearch] = useState("");

  function SearchAttempt() {
    //The parameters of the call
    let getParam = { method: "GET" };
    console.log("find me adam: ", global.JWT);
    let head = { Authorization: `Bearer ${global.JWT}` };
    getParam.headers = head;

    //The URL
    const baseUrl = "https://cab230.hackhouse.sh/search?";
    const query = "offence=" + search;
    const url = baseUrl + query;
    console.log(url);

    fetch(encodeURI(url), getParam)
      .then(function(response) {
        if (response.ok) {
          return response.json();
        }
        throw new Error("Network response was not ok.");
      })
      .then(function(result) {
        let appDiv = document.getElementById("app");
        appDiv.innerHTML = JSON.stringify(result);
      })
      .catch(function(error) {
        console.log(
          "There has been a problem with your fetch operation: ",
          error.message
        );
      });
  }

  return (
    <div className="App">
      <h2>Search:</h2>
      <form
        onSubmit={event => {
          event.preventDefault();
          //console.log(event.target.elements.name.value);
        }}
      >
        <label htmlFor="name">Search:</label>
        <input
          name="text"
          id="text"
          type="text"
          placeholder="Enter query"
          value={search}
          onChange={event => {
            setSearch(event.target.value);
            console.log(search);
          }}
        />
        <button
          onClick={event => {
            SearchAttempt();
          }}
          type="submit"
        >
          Search
        </button>
      </form>
    </div>
  );
}
