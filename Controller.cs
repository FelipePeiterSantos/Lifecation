using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Controller : MonoBehaviour {
	
	public RawImage img;
	public RawImage textImg;
	public RawImage text1Img;
	public Texture[] photos;
	public Texture[] textSlide;
	public RawImage[] btns;
	public Animator anim;
	public AudioSource audioSource;
	public AudioClip[] musics;

	bool hideHUD;

	Vector3 mousePos;
	float cdMouse;
	
	void Start () {
		img.color = Color.clear;
		mousePos = Input.mousePosition;
		cdMouse = 0;
		img.texture = photos [6];
		textImg.texture = textSlide [6];
		audioSource.clip = musics [6];
		audioSource.Play ();
		hideHUD = false;
		img.color = Color.white;
	}

	void FixedUpdate(){
		if(mousePos == Input.mousePosition){
			cdMouse += Time.deltaTime;
			if(cdMouse > 2f){
				hideHUD = true;
				Cursor.visible = false;
			}
		}
		else{
			cdMouse = 0;
			hideHUD = false;
			Cursor.visible = true;
		}
		foreach (RawImage btn in btns) {
			if(hideHUD){
				btn.color = Color.clear;
			}
			else{
				btn.color = Color.white;
			}
		}
		mousePos = Input.mousePosition;
	}

	public void Btn (int aux) {
		if(aux == 7){
			Application.Quit();
		}
		else if(aux == 8){
			anim.SetTrigger("click");
			if(img.texture == photos [6]){
				text1Img.color = Color.white;
			}
			else{
				text1Img.color = Color.clear;
			}
		}
		else{
			img.texture = photos [aux];
			textImg.texture = textSlide[aux];
			audioSource.clip = musics [aux];
			audioSource.Play ();
			if(img.texture == photos [6]){
				text1Img.color = Color.white;
			}
			else{
				text1Img.color = Color.clear;
			}
		}
	}
}
