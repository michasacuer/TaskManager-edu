import {
  Button,
  Form,
  Col,
  FormGroup,
  FormControl,
  ControlLabel,
  HelpBlock,
  Alert
} from "react-bootstrap";
import React, { Component } from "react";
import "../../Styles/Forms.css";
import ApiController from "../Helpers/ApiController";

class AddProject extends React.Component {
  constructor(props, context) {
    super(props, context);

    this.state = {
      name: "",
      description: ""
    };
  }

  submit() {
    if (this.state.name.length < 3) {
      window.alert("Wprowadź poprawna nazwę!");
      return;
    }
    ApiController.api("Projects").post(this.state);
  }

  getValidationState() {
    const length = this.state.name.length;
    if (length > 3) return "success";
    else if (length > 0) return "error";
    return null;
  }

  handleChangeName(e) {
    this.setState({ name: e.target.value });
  }

  handleChangeDesc(e) {
    this.setState({ description: e.target.value });
  }

  render() {
    return (
      <form className="text" horizontal>
        <FormGroup
          controlId="formBasicText"
          validationState={this.getValidationState()}
        >
          <ControlLabel>Nazwa</ControlLabel>
          <FormControl
            type="text"
            name={this.state.name}
            placeholder="Enter text"
            onChange={this.handleChangeName.bind(this)}
          />
          <FormControl.Feedback />
          <HelpBlock>Nazwa nie może być krótsza niż 3 znaki!</HelpBlock>
        </FormGroup>
        <FormGroup controlId="formBasicText">
          <ControlLabel>Opis</ControlLabel>
          <FormControl
            type="text"
            description={this.state.description}
            placeholder="Enter text"
            onChange={this.handleChangeDesc.bind(this)}
          />
        </FormGroup>
        <FormGroup>
          <Col smOffset={2} sm={10}>
            <Button
              className="succes-button"
              bsStyle="success"
              onClick={this.submit.bind(this)}
            >
              Dodaj projekt
            </Button>
          </Col>
        </FormGroup>
      </form>
    );
  }
}

export default AddProject;
