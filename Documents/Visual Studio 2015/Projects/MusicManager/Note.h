
using namespace std;
class Note {
public:
	int mDuration;
	int mOctave;
	Note();
	Note(char name, int freq); 
	char getName();
	int getFreq();
	int getOct();
	int getDur();
	void changeOctave(int octave);
	void changeDuration(int duration);

private:

	char mName;
	int mFreq;
};