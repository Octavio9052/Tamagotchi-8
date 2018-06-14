package com.outlook.octavio.armenta.tamagotchi9052.views.fragments

import android.os.Bundle
import android.support.v4.app.Fragment
import android.support.v7.app.AppCompatActivity
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Button
import android.widget.ImageView
import android.widget.TextView
import com.akexorcist.roundcornerprogressbar.IconRoundCornerProgressBar
import com.bumptech.glide.Glide
import com.outlook.octavio.armenta.tamagotchi9052.R
import kotlinx.android.synthetic.main.fragment_pet.view.*

class PetFragment : Fragment() {

    private var petImageState: ImageView? = null
    private var maxFood: Float = 0.0f
    private var maxRest: Float = 0.0f
    private var maxFun: Float = 0.0f

    // The onCreateView method is called when Fragment should create its View object hierarchy,
    // either dynamically or via XML layout inflation.
    override fun onCreateView(inflater: LayoutInflater, parent: ViewGroup?, savedInstanceState: Bundle?): View? {
        // Defines the xml file for the fragment

        return inflater.inflate(R.layout.fragment_pet, parent, false)
    }

    // Any view setup should occur here.  E.g., view lookups and attaching view listeners.
    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        // Setup any handles to view objects here
        // TODO: Dynamically changes Toolbar title to Pet Name
        (activity as AppCompatActivity).supportActionBar!!.setTitle("Morris")
        // TODO: Remove after service
        setMaxValues(view)

        super.onViewCreated(view, savedInstanceState)
        petImageState = view.findViewById(R.id.state_image_pet)


        // TODO: Remove after service
        view.findViewById<Button>(R.id.pet_action_play).setOnClickListener {
            setPetPlayAnimation()
            changeFunBar((Math.random() * 50).toFloat())

            changeRestBar((Math.random() * -50).toFloat())

            printlog("Morris has played")
        }
        view.findViewById<Button>(R.id.pet_action_eat).setOnClickListener {
            setPetEatAnimation()
            changeFoodBar((Math.random() * 50).toFloat())

            changeFunBar(((Math.random() * -50).toFloat()))

            printlog("Morris has eaten")
        }
        view.findViewById<Button>(R.id.pet_action_sleep).setOnClickListener {
            setPetSleepAnimation()
            changeRestBar((Math.random() * 50).toFloat())

            changeFoodBar((Math.random() * -50).toFloat())

            printlog("Morris has slept")
        }
    }

    // TODO: Remove/change after service
    fun printlog(message: String) {
        val newLog = TextView(context)
        newLog.text = message
        newLog.textSize = 20F
        view!!.pet_logs_container_layout.addView(newLog, 0)
    }

    // TODO: Remove/change after service
    fun setMaxValues(view: View) {
        maxFood = view.findViewById<IconRoundCornerProgressBar>(R.id.pet_health_bar).max
        maxFun = view.findViewById<IconRoundCornerProgressBar>(R.id.pet_fun_bar).max
        maxRest = view.findViewById<IconRoundCornerProgressBar>(R.id.pet_rest_bar).max
    }

    // TODO: Remove/change after service
    override fun onStart() {
        super.onStart()
        changeImage("http://i.imgur.com/vRQWS9E.gif")
    }

    // TODO: Remove/change after service
    fun setPetEatAnimation() {
        changeImage("https://i.imgur.com/axRldeK.gif")
    }

    // TODO: Remove/change after service
    fun setPetPlayAnimation() {
        changeImage("https://i.imgur.com/1sUenIE.gif")
    }

    // TODO: Remove/change after service
    fun setPetSleepAnimation() {
        changeImage("https://i.imgur.com/K3lZbhc.gif")
    }

    // TODO: Remove/change after service
    fun changeImage(currentStateImageUri: String) {
        Glide.with(activity!!).load(currentStateImageUri).into(petImageState!!)
    }

    // TODO: Remove/change after service
    // com.akexorcist.roundcornerprogressbar.IconRoundCornerProgressBar
    fun changeFoodBar(number: Float) {
        val foodBar = view!!.findViewById<IconRoundCornerProgressBar>(R.id.pet_health_bar)
        if (foodBar.progress + number > maxFood) foodBar.progress = 100f
        else foodBar.progress += number
    }

    // TODO: Remove/change after service
    fun changeFunBar(number: Float) {
        val funBar = view!!.findViewById<IconRoundCornerProgressBar>(R.id.pet_fun_bar)
        if (funBar.progress + number > maxFood) funBar.progress = 100f
        else funBar.progress += number
    }

    // TODO: Remove/change after service
    fun changeRestBar(number: Float) {
        val restBar = view!!.findViewById<IconRoundCornerProgressBar>(R.id.pet_rest_bar)
        if (restBar.progress + number > maxFood) restBar.progress = 100f
        else restBar.progress += number
    }
}
