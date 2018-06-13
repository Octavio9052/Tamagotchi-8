/**
 * SOAPServiceCallbackHandler.java
 *
 * This file was auto-generated from WSDL
 * by the Apache Axis2 version: 1.7.8  Built on : May 19, 2018 (07:06:11 BST)
 */
package com.outlook.octavio.armenta.ws;


/**
 *  SOAPServiceCallbackHandler Callback class, Users can extend this class and implement
 *  their own receiveResult and receiveError methods.
 */
public abstract class SOAPServiceCallbackHandler {
    protected Object clientData;

    /**
     * User can pass in any object that needs to be accessed once the NonBlocking
     * Web service call is finished and appropriate method of this CallBack is called.
     * @param clientData Object mechanism by which the user can pass in user data
     * that will be avilable at the time this callback is called.
     */
    public SOAPServiceCallbackHandler(Object clientData) {
        this.clientData = clientData;
    }

    /**
     * Please use this constructor if you don't want to set any clientData
     */
    public SOAPServiceCallbackHandler() {
        this.clientData = null;
    }

    /**
     * Get the client data
     */
    public Object getClientData() {
        return clientData;
    }

    /**
     * auto generated Axis2 call back method for updateAnimal method
     * override this method for handling normal response from updateAnimal operation
     */
    public void receiveResultupdateAnimal(
        com.outlook.octavio.armenta.ws.SOAPServiceStub.UpdateAnimalResponse result) {
    }

    /**
     * auto generated Axis2 Error handler
     * override this method for handling error response from updateAnimal operation
     */
    public void receiveErrorupdateAnimal(Exception e) {
    }

    /**
     * auto generated Axis2 call back method for login method
     * override this method for handling normal response from login operation
     */
    public void receiveResultlogin(
        com.outlook.octavio.armenta.ws.SOAPServiceStub.LoginResponse result) {
    }

    /**
     * auto generated Axis2 Error handler
     * override this method for handling error response from login operation
     */
    public void receiveErrorlogin(Exception e) {
    }

    /**
     * auto generated Axis2 call back method for updateUser method
     * override this method for handling normal response from updateUser operation
     */
    public void receiveResultupdateUser(
        com.outlook.octavio.armenta.ws.SOAPServiceStub.UpdateUserResponse result) {
    }

    /**
     * auto generated Axis2 Error handler
     * override this method for handling error response from updateUser operation
     */
    public void receiveErrorupdateUser(Exception e) {
    }

    /**
     * auto generated Axis2 call back method for createUser method
     * override this method for handling normal response from createUser operation
     */
    public void receiveResultcreateUser(
        com.outlook.octavio.armenta.ws.SOAPServiceStub.CreateUserResponse result) {
    }

    /**
     * auto generated Axis2 Error handler
     * override this method for handling error response from createUser operation
     */
    public void receiveErrorcreateUser(Exception e) {
    }

    /**
     * auto generated Axis2 call back method for deleteAnimal method
     * override this method for handling normal response from deleteAnimal operation
     */
    public void receiveResultdeleteAnimal(
        com.outlook.octavio.armenta.ws.SOAPServiceStub.DeleteAnimalResponse result) {
    }

    /**
     * auto generated Axis2 Error handler
     * override this method for handling error response from deleteAnimal operation
     */
    public void receiveErrordeleteAnimal(Exception e) {
    }

    /**
     * auto generated Axis2 call back method for createAnimal method
     * override this method for handling normal response from createAnimal operation
     */
    public void receiveResultcreateAnimal(
        com.outlook.octavio.armenta.ws.SOAPServiceStub.CreateAnimalResponse result) {
    }

    /**
     * auto generated Axis2 Error handler
     * override this method for handling error response from createAnimal operation
     */
    public void receiveErrorcreateAnimal(Exception e) {
    }

    /**
     * auto generated Axis2 call back method for getAnimal method
     * override this method for handling normal response from getAnimal operation
     */
    public void receiveResultgetAnimal(
        com.outlook.octavio.armenta.ws.SOAPServiceStub.GetAnimalResponse result) {
    }

    /**
     * auto generated Axis2 Error handler
     * override this method for handling error response from getAnimal operation
     */
    public void receiveErrorgetAnimal(Exception e) {
    }
}
