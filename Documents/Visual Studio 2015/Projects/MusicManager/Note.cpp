#include "Note.h";

/*Default Note Constructor*/
Note::Note() {
	mName = '\0'; 
	mFreq = 0; 
	mDuration = 0;
	mOctave = -1; 
}

/*Constructor with Parameters*/
Note::Note(char name, int freq) {
	mName = name; 
	mFreq = freq;
	mDuration = 0;
	mOctave = -1; 
}

/*Getters for member variables*/
char Note::getName() {
	return mName;
}
int Note::getFreq() {
	return mFreq;
}
int Note::getOct() {
	return mOctave;
}
int Note::getDur() {
	return mDuration; 
}


/*Changes mOctave to parameter passed in*/
void Note::changeOctave(int octave) {
	mOctave = octave;
}
/*Changes mDuration to parameter passed in*/
void Note::changeDuration(int duration) {
	mDuration = duration; 
}


