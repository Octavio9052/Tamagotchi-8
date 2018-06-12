package com.outlook.octavio.armenta.tamagotchi9052.fragments

import android.os.Bundle
import android.support.v4.app.Fragment
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Button
import android.widget.ImageView

import com.bumptech.glide.Glide
import com.outlook.octavio.armenta.tamagotchi9052.R

class PetFragment : Fragment() {

    private var petImageState: ImageView? = null

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
    }

    // The onCreateView method is called when Fragment should create its View object hierarchy,
    // either dynamically or via XML layout inflation.
    override fun onCreateView(inflater: LayoutInflater, parent: ViewGroup?, savedInstanceState: Bundle?): View? {
        // Defines the xml file for the fragment
        return inflater.inflate(R.layout.fragment_pet, parent, false)
    }

    // This event is triggered soon after onCreateView().
    // Any view setup should occur here.  E.g., view lookups and attaching view listeners.
    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        // Setup any handles to view objects here
        // EditText etFoo = (EditText) view.findViewById(R.id.etFoo);
        super.onViewCreated(view, savedInstanceState)
        petImageState = view.findViewById(R.id.state_image_pet)
        view.findViewById<Button>(R.id.pet_action_play).setOnClickListener { setPetPlayAnimation() }
        view.findViewById<Button>(R.id.pet_action_eat).setOnClickListener { setPetEatAnimation() }
        view.findViewById<Button>(R.id.pet_action_sleep).setOnClickListener { setPetSleepAnimation() }
    }

    override fun onStart() {
        super.onStart()
        changeImage("http://i.imgur.com/vRQWS9E.gif")
    }

    fun setPetEatAnimation() {
        changeImage("https://i.imgur.com/axRldeK.gif")
    }

    fun setPetPlayAnimation() {
        changeImage("https://i.imgur.com/1sUenIE.gif")
    }

    fun setPetSleepAnimation() {
        changeImage("https://i.imgur.com/K3lZbhc.gif")
    }

    fun changeImage(currentStateImageUri: String) {
        Glide.with(activity!!).load(currentStateImageUri).into(petImageState!!)
    }
}
