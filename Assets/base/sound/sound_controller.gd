extends Node


#sfx1
const button_hovered = preload("res://sound/button_hover.mp3")
const button_pressed = preload("res://sound/button_pressed.mp3")

#sfx2
const skywardhero_ui42 = preload("res://sound/skywardhero_ui42.wav")

#bgm
const frozen_winter = preload("res://sound/frozen_winter.mp3")


var button_set: Array
var old_button_set = Array()


func add_sfx():
	button_set = get_tree().get_nodes_in_group("Button")
	for old_button in old_button_set:
		if not is_instance_valid(old_button):
			return
		old_button.pressed.disconnect(on_button_pressed)
		old_button.mouse_entered.disconnect(on_button_hovered)
		old_button.focus_entered.disconnect(on_button_hovered)
	for button in button_set:
		button.pressed.connect(on_button_pressed)
		button.mouse_entered.connect(on_button_hovered)
		button.focus_entered.connect(on_button_hovered)
	old_button_set = button_set


func on_button_hovered():
	play_sfx1("button_hovered")


func on_button_pressed():
	play_sfx1("button_pressed")


func play_sfx1(sfx):
	if sfx == "button_hovered":
		sfx = button_hovered
	elif sfx == "button_pressed":
		sfx = button_pressed

	$SfxPlayer1.stream = sfx
	$SfxPlayer1.play()


func play_sfx2(sfx):
	if sfx == "skywardhero_ui42":
		sfx = skywardhero_ui42
	
	$SfxPlayer2.stream = sfx
	$SfxPlayer2.play()


func play_music(music):
	if music == "frozen_winter":
		music = frozen_winter
	
	$MusicPlayer.stream = music
	$MusicPlayer.play()
