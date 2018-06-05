package com.outlook.octavio.armenta.tamamotchi.Views

import android.support.v7.app.AppCompatActivity
import android.app.LoaderManager.LoaderCallbacks
import android.content.Loader
import android.database.Cursor
import android.os.AsyncTask
import android.os.Bundle
import android.view.inputmethod.EditorInfo
import android.widget.TextView

import com.outlook.octavio.armenta.tamamotchi.R

import kotlinx.android.synthetic.main.activity_login.*

/**
 * A login screen that offers login via email/password.
 */
class LoginActivity : AppCompatActivity(), LoaderCallbacks<Cursor> {

    /**
     * Keep track of the login task to ensure we can cancel it if requested.
     */
    private var mAuthTask: UserLoginTask? = null

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_login)
        // Set up the login form.
        password.setOnEditorActionListener(TextView.OnEditorActionListener { _, id, _ ->
            if (id == EditorInfo.IME_ACTION_DONE || id == EditorInfo.IME_NULL) {
                attemptLogin()
                return@OnEditorActionListener true
            }
            false
        })

        email_sign_in_button.setOnClickListener { attemptLogin() }
    }


    private fun attemptLogin() {

    }

    /**
     * Represents an asynchronous login/registration task used to authenticate
     * the user.
     */
    inner class UserLoginTask internal constructor(private val mEmail: String, private val mPassword: String) : AsyncTask<Void, Void, Boolean>() {

        override fun doInBackground(vararg params: Void): Boolean? {
            // TODO: attempt authentication against a network service.

            try {
                // Simulate network access.
                Thread.sleep(2000)
            } catch (e: InterruptedException) {
                return false
            }

            return null
            /*DUMMY_CREDENTIALS
                    .map { it.split(":") }
                    .firstOrNull { it[0] == mEmail }
                    ?.let {
                        // Account exists, return true if the password matches.
                        it[1] == mPassword
                    }
                    ?: true*/
        }

        override fun onPostExecute(success: Boolean?) {
            mAuthTask = null

            if (success!!) {
                finish()
            } else {
                password.error = getString(R.string.error_incorrect_password)
                password.requestFocus()
            }
        }

        override fun onCancelled() {
            mAuthTask = null
        }
    }






    private fun isEmailValid(email: String): Boolean {
        //TODO: Replace this with your own logic
        return email.contains("@")
    }

    private fun isPasswordValid(password: String): Boolean {
        //TODO: Replace this with your own logic
        return password.length > 4
    }

    override fun onCreateLoader(id: Int, args: Bundle?): Loader<Cursor> {
        TODO("not implemented") //To change body of created functions use File | Settings | File Templates.
    }

    override fun onLoadFinished(loader: Loader<Cursor>?, data: Cursor?) {
        TODO("not implemented") //To change body of created functions use File | Settings | File Templates.
    }

    override fun onLoaderReset(loader: Loader<Cursor>?) {
        TODO("not implemented") //To change body of created functions use File | Settings | File Templates.
    }
}
