import React, { Component } from "react";
import { Navbar, NavDropdown, MenuItem, NavItem, Nav } from "react-bootstrap";

class NavBar extends Component {
  render() {
    return (
      <Navbar inverse collapseOnSelect>
        <Navbar.Header>
          <Navbar.Brand>
            <a href="#brand">Mini Jira</a>
          </Navbar.Brand>
          <Navbar.Toggle />
        </Navbar.Header>
        <Navbar.Collapse>
          <Nav>
            <NavItem eventKey={1} href="#">
              Projekty
            </NavItem>
          </Nav>
          <Nav pullRight>
            <NavItem eventKey={1} href="#">
              Wyloguj się
            </NavItem>
          </Nav>
        </Navbar.Collapse>
      </Navbar>
    );
  }
}

export default NavBar;
