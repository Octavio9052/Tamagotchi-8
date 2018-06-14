package com.outlook.octavio.armenta.tamagotchi9052.views.fragments

import android.content.Intent
import android.os.Bundle
import android.support.v4.app.Fragment
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Button
import android.widget.EditText
import android.widget.Toast
import com.outlook.octavio.armenta.tamagotchi9052.R
import com.outlook.octavio.armenta.tamagotchi9052.models.Login
import com.outlook.octavio.armenta.tamagotchi9052.views.activities.MainActivity
import com.outlook.octavio.armenta.tamagotchi9052.views.activities.StoreActivity
import com.outlook.octavio.armenta.tamagotchi9052.web.messages.LoginRequest
import com.outlook.octavio.armenta.tamagotchi9052.web.messages.LoginResponse
import com.outlook.octavio.armenta.tamagotchi9052.web.services.LoginService
import com.outlook.octavio.armenta.tamagotchi9052.web.services.WebServiceFactory

import retrofit2.Call
import retrofit2.Callback
import retrofit2.Response

class RegisterFragment : Fragment() {

    // The onCreateView method is called when Fragment should create its View object hierarchy,
    // either dynamically or via XML layout inflation.
    override fun onCreateView(inflater: LayoutInflater, parent: ViewGroup?, savedInstanceState: Bundle?): View? {
        // Defines the xml file for the fragment
        return inflater.inflate(R.layout.fragment_register, parent, false)
    }

    // Any view setup should occur here.  E.g., view lookups and attaching view listeners.
    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        // Setup any handles to view objects here
        // EditText etFoo = (EditText) view.findViewById(R.id.etFoo);
        super.onViewCreated(view, savedInstanceState)
        // petImageState = view.findViewById(R.id.state_image_pet)

        view.findViewById<Button>(R.id.register_create_account).setOnClickListener {
            val pass = view.findViewById<EditText>(R.id.register_input_password).text.toString()
            val email = view.findViewById<EditText>(R.id.register_input_email).text.toString()
            val name = view.findViewById<EditText>(R.id.register_input_name).text.toString()

            doRegister(email, pass, name)
        }
    }


    fun doRegister(email: String, pass: String, name: String) {
        val login = Login(email, pass)

        val webServiceFactory = WebServiceFactory().getService(LoginService::class.java)

        val repos = webServiceFactory?.Register(LoginRequest(login, name))?.enqueue(object : Callback<LoginResponse> {
            override fun onFailure(call: Call<LoginResponse>?, t: Throwable?) {
                Toast.makeText(context, "Couldn't reach server", Toast.LENGTH_LONG).show()
            }

            override fun onResponse(call: Call<LoginResponse>?, response: Response<LoginResponse>?) {
                if(response?.raw()!!.isSuccessful) doLogin() else Toast.makeText(context, "Couldn't create user", Toast.LENGTH_LONG).show()
                println(response)
            }
        })
    }

    fun attempLogin() {
        if (checkCredential()) {
            doLogin()
        } else {

        }
    }

    fun checkCredential(): Boolean {
        return true
    }

    fun doLogin() {
        val intent = Intent(activity, StoreActivity::class.java)
        startActivity(intent)
    }

    fun passwordsMatch() {

    }

    fun getToken() {

    }

    fun getUser() {

    }
}
