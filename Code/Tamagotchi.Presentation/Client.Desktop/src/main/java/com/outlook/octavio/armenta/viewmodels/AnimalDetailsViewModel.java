package com.outlook.octavio.armenta.viewmodels;

import com.cloudinary.Cloudinary;
import com.cloudinary.utils.ObjectUtils;
import com.google.inject.Inject;
import com.outlook.octavio.armenta.services.AuthService;
import com.outlook.octavio.armenta.ws.SOAPServiceStub;
import de.saxsys.mvvmfx.ViewModel;
import de.saxsys.mvvmfx.utils.commands.Action;
import de.saxsys.mvvmfx.utils.commands.Command;
import de.saxsys.mvvmfx.utils.commands.DelegateCommand;
import javafx.beans.property.*;
import javafx.collections.FXCollections;
import javafx.collections.ObservableMap;
import javafx.scene.image.Image;
import org.apache.commons.codec.binary.Base64;

import java.io.File;
import java.io.FileInputStream;
import java.util.Map;


public class AnimalDetailsViewModel implements ViewModel {

    @Inject
    public AnimalDetailsViewModel(AuthService authService) {
        this.authService = authService;
    }

    private final AuthService authService;

    public static final String IDLE_BROWSE = "IDLE_BROWSE";
    public static final String PLAY_BROWSE = "PLAY_BROWSE";
    public static final String SLEEP_BROWSE = "SLEEP_BROWSE";
    public static final String EAT_BROWSE = "EAT_BROWSE";
    public static final String PACKAGE_BROWSE = "PACKAGE_BROWSE";

    private ObjectProperty<Image> idleImage = new SimpleObjectProperty<>();
    private StringProperty idleImageUri = new SimpleStringProperty();
    private ObjectProperty<Image> playImage = new SimpleObjectProperty<>();
    private StringProperty playImageUri = new SimpleStringProperty();
    private ObjectProperty<Image> sleepImage = new SimpleObjectProperty<>();
    private StringProperty sleepImageUri = new SimpleStringProperty();
    private ObjectProperty<Image> eatImage = new SimpleObjectProperty<>();
    private StringProperty eatImageUri = new SimpleStringProperty();

    private ObjectProperty<File> packageProperty = new SimpleObjectProperty<>();
    private StringProperty packageUri = new SimpleStringProperty();

    private StringProperty nameField = new SimpleStringProperty();
    private StringProperty descriptionField = new SimpleStringProperty();
    private StringProperty packageField = new SimpleStringProperty();
    private StringProperty propName = new SimpleStringProperty();

    private MapProperty<StringProperty, StringProperty> dynamicProps = new SimpleMapProperty<>(FXCollections.observableHashMap());

    private Command idleBrowseCommand;
    private Command playBrowseCommand;
    private Command sleepBrowseCommand;
    private Command eatBrowseCommand;
    private Command packageBrowseCommand;
    private Command addPropCommand;
    private Command createCommand;



    public void initialize() {

        idleBrowseCommand = new DelegateCommand(() -> new Action() {
            @Override
            protected void action() throws Exception {
                doIdleBrowse();
            }
        });

        playBrowseCommand = new DelegateCommand(() -> new Action() {
            @Override
            protected void action() throws Exception {
                doPlayBrowse();
            }
        });

        sleepBrowseCommand = new DelegateCommand(() -> new Action() {
            @Override
            protected void action() throws Exception {
                doSleepBrowse();
            }
        });

        eatBrowseCommand = new DelegateCommand(() -> new Action() {
            @Override
            protected void action() throws Exception {
                doEatBrowse();
            }
        });

        packageBrowseCommand = new DelegateCommand(() -> new Action() {
            @Override
            protected void action() throws Exception {
                doPackageBrowse();
            }
        });

        createCommand = new DelegateCommand(() -> new Action() {
            @Override
            protected void action() throws Exception {
                doCreate();
            }
        });


    }

    public void doIdleBrowse() throws Exception {
        publish(IDLE_BROWSE);
    }

    public void doPlayBrowse() {
        publish(PLAY_BROWSE);
    }

    public void doSleepBrowse() {
        publish(SLEEP_BROWSE);
    }

    public void doEatBrowse() {
        publish(EAT_BROWSE);
    }

    public void doPackageBrowse() {
        publish(PACKAGE_BROWSE);
    }

    public void doCreate() {
        // TODO: UPLOAD ANIMAL TO SOAP
        try {
            SOAPServiceStub soapServiceStub = new SOAPServiceStub();

            SOAPServiceStub.MessageRequestOfAnimalModelNuLtuh91 mRequestAnimal = new SOAPServiceStub.MessageRequestOfAnimalModelNuLtuh91();

            SOAPServiceStub.AnimalModel animalModel = new SOAPServiceStub.AnimalModel();

            animalModel.setName(getNameField());
            animalModel.setDescription(getDescriptionField());
            // TODO: Conver to base64 string

            String idleUrl = getHostUrl(getIdleImageUri());
            String eatUrl = getHostUrl(getEatImageUri());
            String sleepUrl = getHostUrl(getSleepImageUri());
            String playUrl = getHostUrl(gePlayImageUri());


            ///////
            animalModel.setPacketFile(encodeFileToBase64Binary(getPackageUri(), false));
            animalModel.setIdleImage(encodeFileToBase64Binary(idleUrl, true));
            animalModel.setEatImage(encodeFileToBase64Binary(eatUrl, true));
            animalModel.setSleepImage(encodeFileToBase64Binary(sleepUrl, true));
            animalModel.setPlayImage(encodeFileToBase64Binary(playUrl, true));
            //////
            animalModel.setPacketUri(getPackageUri());
            animalModel.setIdleUri(idleUrl);
            animalModel.setEatUri(eatUrl);
            animalModel.setSleepUri(sleepUrl);
            animalModel.setPlayUri(playUrl);
            ////////

            mRequestAnimal.setBody(animalModel);
            SOAPServiceStub.Guid guid = new SOAPServiceStub.Guid();
            guid.setGuid(authService.user.getValue().GUID);

            mRequestAnimal.setUserToken(guid);
            // TODO: Access service to get current User and GUID.

            SOAPServiceStub.CreateAnimal createAnimal = new SOAPServiceStub.CreateAnimal();
            createAnimal.setValue(mRequestAnimal);

            SOAPServiceStub.CreateAnimalResponse caResponse = soapServiceStub.createAnimal(createAnimal);
            System.out.println("New animal: " + caResponse.getCreateAnimalResult().getBody().getId());

            System.out.println("Error: " + caResponse.getCreateAnimalResult().getError());


        } catch (Exception e) {
            System.out.println(e.toString());
        }
    }

    private String getHostUrl(String uri) {
        String imageURL;
        Cloudinary cloudinary = new Cloudinary(ObjectUtils.asMap(
                "cloud_name", "octavio9052",
                "api_key", "847159943216128",
                "api_secret", "927_isRXWaPthg3PBD8Zak5xr6I"));
        File toUpload = new File(getIdleImageUri());
        try {
            Map uploadResult = cloudinary.uploader().upload(toUpload, ObjectUtils.emptyMap());
            imageURL = uploadResult.get("url").toString();
        } catch (Exception e) {
            System.out.println("Error: " + e);
            return null;
        }
        return imageURL;
    }

    /**
     * Method used for encode the file to base64 binary format
     */
    private static String encodeFileToBase64Binary(String path, boolean image){
        try {
        String encodedFile = "";

            if (image) {
                byte[] bytesEncoded = Base64.encodeBase64(path.getBytes());
                encodedFile = new String(bytesEncoded);
            } else {
                StringBuilder strBuilder = new StringBuilder(path);
                strBuilder.insert(strBuilder.lastIndexOf("."), "2");
                File dllFile = new File(strBuilder.toString());
                FileInputStream fileInputStreamReader = new FileInputStream(dllFile);
                byte[] bytes = new byte[(int) dllFile.length()];
                fileInputStreamReader.read(bytes);
                encodedFile = new String(Base64.encodeBase64(bytes), "UTF-8");
            }

            return encodedFile;

        } catch (Exception e) {
            System.out.println("Error");

            return null;
        }
    }




        public Image getIdleImage() {
        return idleImage.get();
    }

    public ObjectProperty<Image> idleImageProperty() {
        return idleImage;
    }

    public String getIdleImageUri() {
        return idleImageUri.get();
    }

    public StringProperty idleImageUriProperty() {
        return idleImageUri;
    }

    public Image getPlayImage() {
        return playImage.get();
    }

    public ObjectProperty<Image> playImageProperty() {
        return playImage;
    }

    public String gePlayImageUri() {
        return playImageUri.get();
    }

    public StringProperty playImageUriProperty() {
        return playImageUri;
    }

    public Image getSleepImage() {
        return sleepImage.get();
    }

    public ObjectProperty<Image> sleepImageProperty() {
        return sleepImage;
    }

    public String getSleepImageUri() {
        return sleepImageUri.get();
    }

    public StringProperty sleepImageUriProperty() {
        return sleepImageUri;
    }

    public Image getEatImage() {
        return eatImage.get();
    }

    public ObjectProperty<Image> eatImageProperty() {
        return eatImage;
    }


    public String getEatImageUri() {
        return eatImageUri.get();
    }

    public StringProperty eatImageUriProperty() {
        return eatImageUri;
    }

    public File getPackageProperty() {
        return packageProperty.get();
    }

    public ObjectProperty<File> packagePropertyProperty() {
        return packageProperty;
    }

    public String getPackageUri() {
        return packageUri.get();
    }

    public StringProperty packageUriProperty() {
        return packageUri;
    }

    public String getNameField() {
        return nameField.get();
    }

    public StringProperty nameFieldProperty() {
        return nameField;
    }

    public String getDescriptionField() {
        return descriptionField.get();
    }

    public StringProperty descriptionFieldProperty() {
        return descriptionField;
    }

    public String getPackageField() {
        return packageField.get();
    }

    public StringProperty packageFieldProperty() {
        return packageField;
    }

    public String getPropName() {
        return propName.get();
    }

    public StringProperty propNameProperty() {
        return propName;
    }

    public ObservableMap<StringProperty, StringProperty> getDynamicProps() {
        return dynamicProps.get();
    }

    public MapProperty<StringProperty, StringProperty> dynamicPropsProperty() {
        return dynamicProps;
    }

    public Command getIdleBrowseCommand() {
        return idleBrowseCommand;
    }

    public Command getPlayBrowseCommand() {
        return playBrowseCommand;
    }

    public Command getSleepBrowseCommand() {
        return sleepBrowseCommand;
    }

    public Command getEatBrowseCommand() {
        return eatBrowseCommand;
    }

    public Command getPackageBrowseCommand() {
        return packageBrowseCommand;
    }

    public Command getAddPropCommand() {
        return addPropCommand;
    }

    public Command getCreateCommand() {
        return createCommand;
    }
}
