import {
  Button,
  Form,
  Col,
  FormGroup,
  FormControl,
  ControlLabel
} from "react-bootstrap";
import React, { Component } from "react";
import "../../Styles/Forms.css";
import ApiController from "../Helpers/ApiController";

class AddProject extends Component {
  constructor(props, context) {
    super(props, context);

    this.state = {
      name: "",
      description: ""
    };
  }

  getValidationState() {
    const length = this.state.value.length;
    if (length > 10) return "success";
    else if (length > 5) return "warning";
    else if (length > 0) return "error";
    return null;
  }

  render() {
    return (
      <Form className="text" horizontal>
        <FormGroup controlId="formHorizontalName">
          <Col componentClass={ControlLabel} sm={2}>
            Nazwa
          </Col>
          <Col sm={10}>
            <FormControl type="text" placeholder="Nazwa projektu" />
          </Col>
        </FormGroup>

        <FormGroup controlId="formControlsDescription">
          <Col componentClass={ControlLabel} sm={2}>
            Opis
          </Col>
          <Col sm={10}>
            <FormControl type="text" placeholder="Opis projektu" />
          </Col>
        </FormGroup>

        <FormGroup>
          <Col smOffset={2} sm={10}>
            <Button className="succes-button" type="submit">
              Dodaj projekt
            </Button>
          </Col>
        </FormGroup>
      </Form>
    );
  }
}

export default AddProject;
