import React, { Component } from "react";
import { Navbar, NavItem, Nav } from "react-bootstrap";
import { BrowserRouter as Router, Route, Link } from "react-router-dom";

class NavBar extends Component {
  render() {
    return (
      <Router>
        <Navbar inverse collapseOnSelect>
          <Navbar.Collapse>
            <Nav>
              <Navbar.Brand>
                <Link to="/projects">Projekty</Link>
              </Navbar.Brand>
            </Nav>
            <Nav pullRight>
              <Navbar.Brand>Wyloguj się</Navbar.Brand>
            </Nav>
          </Navbar.Collapse>
        </Navbar>
      </Router>
    );
  }
}

export default NavBar;
